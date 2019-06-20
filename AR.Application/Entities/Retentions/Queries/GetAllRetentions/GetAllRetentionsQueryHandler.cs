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

namespace AR.Application.Entities.Retentions.Queries.GetAllRetentions
{
    public class GetAllRetentionsQueryHandler : IRequestHandler<GetAllRetentionsQuery, RetentionsListViewModel>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllRetentionsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RetentionsListViewModel> Handle(GetAllRetentionsQuery request, CancellationToken cancellationToken)
        {
            var Retentions = await _context.Retentions.ToListAsync(cancellationToken);
            var model = new RetentionsListViewModel
            {
                Retentions = _mapper.Map<IEnumerable<RetentionDto>>(Retentions)
            };
            
            return model;
        }
    }
}
