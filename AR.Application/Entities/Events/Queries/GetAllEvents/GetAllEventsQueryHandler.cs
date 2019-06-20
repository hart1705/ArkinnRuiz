using AR.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dapper;
using AR.Application.Entities.Events.Models;

namespace AR.Application.Entities.Events.Queries.GetAllEvents
{
    public class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, EventsListViewModel>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllEventsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EventsListViewModel> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var events = await _context.Events.ToListAsync(cancellationToken);
            var model = new EventsListViewModel
            {
                Events = _mapper.Map<IEnumerable<EventDto>>(events)
            };
            
            return model;
        }
    }
}
