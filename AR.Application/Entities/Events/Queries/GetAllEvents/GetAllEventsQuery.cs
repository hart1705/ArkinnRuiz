using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Events.Queries.GetAllEvents
{
    public class GetAllEventsQuery : IRequest<EventsListViewModel>
    {
    }
}
