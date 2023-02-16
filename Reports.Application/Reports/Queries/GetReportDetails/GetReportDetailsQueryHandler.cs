
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reports.Application.Exceptions;
using Reports.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Reports.Application.Reports.Queries.GetReportDetails
{
    public class GetReportDetailsQueryHandler
        : IRequestHandler<GetReportDetailsQuery, ReportDetailVm>
    {
        private readonly IReportsDbContext _context;
        private readonly IMapper _mapper;

        public GetReportDetailsQueryHandler(IReportsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ReportDetailVm> Handle(GetReportDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Reports.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundExceptions(nameof(Reports), request.Id);
            }
            return _mapper.Map<ReportDetailVm>(entity);
        }
    }
}
