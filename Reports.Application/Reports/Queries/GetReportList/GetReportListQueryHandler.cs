

using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reports.Application.Interfaces;


namespace Reports.Application.Reports.Queries.GetReportList
{
    public class GetReportListQueryHandler : IRequestHandler<GetReportListQuery, ReportListVm>
    {
        private readonly IReportsDbContext _context;
        private readonly IMapper _mapper;

        public GetReportListQueryHandler(IReportsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReportListVm> Handle(GetReportListQuery request, CancellationToken cancellationToken)
        {
            var reportsQuery = await _context.Reports
                .Where(note => note.UserId == request.UserId)
                .ProjectTo<ReportLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new ReportListVm { Reports = reportsQuery };
        }
    }
}
