using AR.Application.Entities.Retentions.Models;
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

namespace AR.Application.Entities.Retentions.Queries.GetRetentionWaiver
{
    public class GetRetentionWaiverQueryHandler : MediatR.IRequestHandler<GetRetentionWaiverQuery, RetentionWaiverDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public GetRetentionWaiverQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RetentionWaiverDto> Handle(GetRetentionWaiverQuery request, CancellationToken cancellationToken)
        {
            var RetentionWaivers = _mapper.Map<RetentionWaiverDto>(await _context
                .RetentionWaiver.Where(a => a.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (RetentionWaivers == null)
            {
                throw new NotFoundException(nameof(RetentionWaiver), request.Id);
            }

            return RetentionWaivers;
        }
    }
}
