using AR.Application.Exceptions;
using AR.Domain.Entities;
using AR.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Retentions.Commands.DeleteRetentionApproval
{
    public class DeleteRetentionApprovalCommandHandler : IRequestHandler<DeleteRetentionApprovalCommand>
    {
        private readonly ApplicationDbContext _context;

        public DeleteRetentionApprovalCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRetentionApprovalCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RetentionApproval.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Retention), request.Id);
            }

            _context.RetentionApproval.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
