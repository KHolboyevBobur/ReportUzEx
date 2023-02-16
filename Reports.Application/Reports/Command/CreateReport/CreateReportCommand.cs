using MediatR;
using System;

namespace Reports.Application.Reports.Command.CreateReport
{
    public class CreateNoteCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}