using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Events.Commands.UpdateEvent
{
    public class UpdateEventCommand : IRequest<string>
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
