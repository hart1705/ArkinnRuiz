using AR.Application.Exceptions;
using AR.Domain.Entities;
using AR.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Retentions.Commands.DeleteRetentionUnit
{
    public class DeleteRetentionUnitCommandHandler : IRequestHandler<DeleteRetentionUnitCommand>
    {
        private readonly ApplicationDbContext _context;

        public DeleteRetentionUnitCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRetentionUnitCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RetentionUnit.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Retention), request.Id);
            }

            _context.RetentionUnit.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
