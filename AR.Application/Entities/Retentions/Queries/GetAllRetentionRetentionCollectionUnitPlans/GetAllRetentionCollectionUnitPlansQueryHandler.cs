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
using AR.Application.Entities.Retentions.Models;
using System.Linq;

namespace AR.Application.Entities.Retentions.Queries.GetAllRetentionCollectionUnitPlans
{
    public class GetAllRetentionCollectionUnitPlansQueryHandler : IRequestHandler<GetAllRetentionCollectionUnitPlansQuery, RetentionCollectionUnitPlansListViewModel>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllRetentionCollectionUnitPlansQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RetentionCollectionUnitPlansListViewModel> Handle(GetAllRetentionCollectionUnitPlansQuery request, CancellationToken cancellationToken)
        {
            var RetentionCollectionUnitPlans = await _context.RetentionCollectionUnitPlan
                .Where(a=> a.UnitType == request.UnitType)
                .ToListAsync(cancellationToken);
            var model = new RetentionCollectionUnitPlansListViewModel
            {
                RetentionCollectionUnitPlans = _mapper.Map<IEnumerable<RetentionCollectionUnitPlanDto>>(RetentionCollectionUnitPlans)
            };
            
            return model;
        }
    }
}
