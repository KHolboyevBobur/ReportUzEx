using MediatR;

namespace Reports.Application.Reports.Command.UpdateReport
{
    public class UpdateReportCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }

    }
}
