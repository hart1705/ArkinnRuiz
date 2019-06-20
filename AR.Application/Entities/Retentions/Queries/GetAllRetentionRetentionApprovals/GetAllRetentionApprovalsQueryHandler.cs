using AR.Persistence;
using AutoMapper;
using MediatR;
using System;
using LinqKit;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dapper;
using AR.Application.Entities.Retentions.Models;
using AR.Application.Helpers;
using System.Linq.Expressions;
using AR.Domain.Entities;
using System.Linq;

namespace AR.Application.Entities.Retentions.Queries.GetAllRetentionApprovals
{
    public class GetAllRetentionApprovalsQueryHandler : IRequestHandler<GetAllRetentionApprovalsQuery, RetentionApprovalsListViewModel>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllRetentionApprovalsQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RetentionApprovalsListViewModel> Handle(GetAllRetentionApprovalsQuery request, CancellationToken cancellationToken)
        {
            //var result = new List<RetentionApprovalDto>();
            //var searchBy = (request != null) ? request.search.value : null;
            //var whereClause = BuildDynamicWhereClause(_context, searchBy);

            var result = await _context.RetentionApproval

                .Where(a => a.ApprovalType == request.ApprovalType)

                .ToListAsync(cancellationToken);

            //return new DataTableAjaxResponse<IEnumerable<RetentionApprovalDto>>
            //{
            //    draw = request.draw,
            //    recordsTotal = _context.RetentionApproval.Count(),
            //    recordsFiltered = result.RowCount,
            //    data = result
            //};
            //var RetentionApprovals = await _context.RetentionApproval.ToListAsync(cancellationToken);
            var model = new RetentionApprovalsListViewModel
            {
                RetentionApprovals = _mapper.Map<IEnumerable<RetentionApprovalDto>>(result)
            };

            return model;
        }

        //private Expression<Func<RetentionApproval, bool>> BuildDynamicWhereClause(ApplicationDbContext entities, string searchValue)
        //{
        //    var predicate = PredicateBuilder.New<RetentionApproval>(true);
        //    if (string.IsNullOrWhiteSpace(searchValue) == false)
        //    {
        //        var searchTerms = searchValue.Split(' ').ToList().ConvertAll(x => x.ToLower());
        //        predicate = predicate.Or(s => searchTerms.Any(srch => s.ApprovalType.Contains(srch)));
        //    }
        //    return predicate;
        //}
    }
}
