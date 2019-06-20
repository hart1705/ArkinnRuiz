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

namespace AR.Application.Entities.Retentions.Queries.GetAllRetentionUnits
{
    public class GetAllRetentionUnitsQueryHandler : IRequestHandler<GetAllRetentionUnitsQuery, RetentionUnitsListViewModel>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllRetentionUnitsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RetentionUnitsListViewModel> Handle(GetAllRetentionUnitsQuery request, CancellationToken cancellationToken)
        {
            var RetentionUnits = await _context.RetentionUnit
                .Where(a=>a.UnitType == request.UnitType)
                .ToListAsync(cancellationToken);
            var model = new RetentionUnitsListViewModel
            {
                RetentionUnits = _mapper.Map<IEnumerable<RetentionUnitDto>>(RetentionUnits)
            };
            
            return model;
        }
    }
}
