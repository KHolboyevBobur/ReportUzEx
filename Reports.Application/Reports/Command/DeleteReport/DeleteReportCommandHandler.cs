using MediatR;
using Reports.Application.Exceptions;
using Reports.Application.Interfaces;
using Reports.Domain;

namespace Reports.Application.Reports.Command.DeleteReport
{
    public class DeleteReportCommandHandler : IRequestHandler<DeleteReportCommand>
    {
        private readonly IReportsDbContext _dbcontext;
        public DeleteReportCommandHandler(IReportsDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Unit> Handle(DeleteReportCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Reports.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundExceptions(nameof(Report), request.Id);
            }

            _dbcontext.Reports.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
