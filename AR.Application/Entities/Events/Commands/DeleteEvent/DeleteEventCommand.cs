using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Events.Commands.DeleteEvent
{
    public class DeleteEventCommand : IRequest
    {
        public string Id { get; set; }
    }
}
