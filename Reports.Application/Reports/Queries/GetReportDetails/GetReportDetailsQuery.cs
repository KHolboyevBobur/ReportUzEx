using MediatR;

namespace Reports.Application.Reports.Queries.GetReportDetails
{
    public class GetReportDetailsQuery : IRequest<ReportDetailVm>
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
