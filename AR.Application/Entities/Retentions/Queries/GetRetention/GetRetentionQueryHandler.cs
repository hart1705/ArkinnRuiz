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

namespace AR.Application.Entities.Retentions.Queries.GetRetention
{
    public class GetRetentionQueryHandler : MediatR.IRequestHandler<GetRetentionQuery, RetentionDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public GetRetentionQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RetentionDto> Handle(GetRetentionQuery request, CancellationToken cancellationToken)
        {
            var Retentions = _mapper.Map<RetentionDto>(await _context
                .Retentions.Where(a => a.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (Retentions == null)
            {
                throw new NotFoundException(nameof(Retention), request.Id);
            }

            return Retentions;
        }
    }
}
