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

namespace AR.Application.Entities.Retentions.Queries.GetRetentionUnit
{
    public class GetRetentionUnitQueryHandler : MediatR.IRequestHandler<GetRetentionUnitQuery, RetentionUnitDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public GetRetentionUnitQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RetentionUnitDto> Handle(GetRetentionUnitQuery request, CancellationToken cancellationToken)
        {
            var RetentionUnits = _mapper.Map<RetentionUnitDto>(await _context
                .RetentionUnit.Where(a => a.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (RetentionUnits == null)
            {
                throw new NotFoundException(nameof(RetentionUnit), request.Id);
            }

            return RetentionUnits;
        }
    }
}
