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

namespace AR.Application.Entities.Retentions.Queries.GetRetentionCollectionUnitPlan
{
    public class GetRetentionCollectionUnitPlanQueryHandler : MediatR.IRequestHandler<GetRetentionCollectionUnitPlanQuery, RetentionCollectionUnitPlanDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public GetRetentionCollectionUnitPlanQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RetentionCollectionUnitPlanDto> Handle(GetRetentionCollectionUnitPlanQuery request, CancellationToken cancellationToken)
        {
            var RetentionCollectionUnitPlans = _mapper.Map<RetentionCollectionUnitPlanDto>(await _context
                .RetentionCollectionUnitPlan.Where(a => a.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (RetentionCollectionUnitPlans == null)
            {
                throw new NotFoundException(nameof(RetentionCollectionUnitPlan), request.Id);
            }

            return RetentionCollectionUnitPlans;
        }
    }
}
