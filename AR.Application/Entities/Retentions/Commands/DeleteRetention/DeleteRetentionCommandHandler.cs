using AR.Application.Exceptions;
using AR.Domain.Entities;
using AR.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Retentions.Commands.DeleteRetention
{
    public class DeleteRetentionCommandHandler : IRequestHandler<DeleteRetentionCommand>
    {
        private readonly ApplicationDbContext _context;

        public DeleteRetentionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRetentionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Retentions.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Retention), request.Id);
            }

            _context.Retentions.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
