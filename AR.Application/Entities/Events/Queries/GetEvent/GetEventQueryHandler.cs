using AR.Application.Entities.Events.Models;
using AR.Application.Exceptions;
using AR.Domain.Entities;
using AR.Persistence;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Events.Queries.GetEvent
{
    public class GetEventQueryHandler : MediatR.IRequestHandler<GetEventQuery, EventDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public GetEventQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EventDto> Handle(GetEventQuery request, CancellationToken cancellationToken)
        {
            var events = _mapper.Map<EventDto>(await _context
                .Events.Where(a => a.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (events == null)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }

            return events;
        }
    }
}
