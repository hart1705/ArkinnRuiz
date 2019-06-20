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

namespace AR.Application.Entities.Retentions.Queries.GetAllRetentionWaivers
{
    public class GetAllRetentionWaiversQueryHandler : IRequestHandler<GetAllRetentionWaiversQuery, RetentionWaiversListViewModel>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllRetentionWaiversQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RetentionWaiversListViewModel> Handle(GetAllRetentionWaiversQuery request, CancellationToken cancellationToken)
        {
            var RetentionWaivers = await _context.RetentionWaiver.ToListAsync(cancellationToken);
            var model = new RetentionWaiversListViewModel
            {
                RetentionWaivers = _mapper.Map<IEnumerable<RetentionWaiverDto>>(RetentionWaivers)
            };
            
            return model;
        }
    }
}
