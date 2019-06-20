using AR.Application.Entities.Events.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Events.Queries.GetEvent
{
    public class GetEventQuery : IRequest<EventDto>
    {
        public string Id { get; set; }
    }
}
