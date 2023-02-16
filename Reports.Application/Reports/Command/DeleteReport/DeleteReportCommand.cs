using MediatR;
using System;

namespace Reports.Application.Reports.Command.DeleteReport
{
    public class DeleteReportCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
