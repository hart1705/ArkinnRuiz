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

namespace AR.Application.Entities.Retentions.Queries.GetRetentionApproval
{
    public class GetRetentionApprovalQueryHandler : MediatR.IRequestHandler<GetRetentionApprovalQuery, RetentionApprovalDto>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        
        public GetRetentionApprovalQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RetentionApprovalDto> Handle(GetRetentionApprovalQuery request, CancellationToken cancellationToken)
        {
            var RetentionApprovals = _mapper.Map<RetentionApprovalDto>(await _context
                .RetentionApproval.Where(a => a.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken));

            if (RetentionApprovals == null)
            {
                throw new NotFoundException(nameof(RetentionApproval), request.Id);
            }

            return RetentionApprovals;
        }
    }
}
