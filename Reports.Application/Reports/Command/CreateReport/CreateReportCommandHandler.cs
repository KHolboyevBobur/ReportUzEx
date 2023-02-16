
using MediatR;
using Reports.Application.Interfaces;
using Reports.Domain;


namespace Reports.Application.Reports.Command.CreateReport
{
    public class CreateNoteCommandHandler
        : IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly IReportsDbContext _dbcontext;
        public CreateNoteCommandHandler(IReportsDbContext dbcontext) =>
            _dbcontext = dbcontext;

        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var r = new Report
            {
                UserId = request.UserId,
                Title = request.Title,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null

            };
            await _dbcontext.Reports.AddAsync(r, cancellationToken);
            await _dbcontext.SaveChangesAsync(cancellationToken);
            return r.Id;
        }
    }
}
