using MediatR;
using Microsoft.EntityFrameworkCore;
using Reports.Application.Exceptions;
using Reports.Application.Interfaces;

namespace Reports.Application.Reports.Command.UpdateReport
{
    public class UpdateReportCommandHandler : IRequestHandler<UpdateReportCommand>
    {
        private readonly IReportsDbContext _dbcontext;
        public UpdateReportCommandHandler(IReportsDbContext dbcontext) => _dbcontext = dbcontext;

        public async Task<Unit> Handle(UpdateReportCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbcontext.Reports.FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundExceptions(nameof(Reports), request.Id);
            }

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            await _dbcontext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
