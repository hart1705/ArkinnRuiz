using AR.Application.Entities.Events.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Events.Queries.GetAllEvents
{
    public class EventsListViewModel
    {
        public IEnumerable<EventDto> Events { get; set; }
    }
}
