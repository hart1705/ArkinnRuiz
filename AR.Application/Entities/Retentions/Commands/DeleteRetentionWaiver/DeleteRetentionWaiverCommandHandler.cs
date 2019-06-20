using AR.Application.Exceptions;
using AR.Domain.Entities;
using AR.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Retentions.Commands.DeleteRetentionWaiver
{
    public class DeleteRetentionWaiverCommandHandler : IRequestHandler<DeleteRetentionWaiverCommand>
    {
        private readonly ApplicationDbContext _context;

        public DeleteRetentionWaiverCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRetentionWaiverCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RetentionWaiver.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Retention), request.Id);
            }

            _context.RetentionWaiver.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
