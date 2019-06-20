using AR.Application.Exceptions;
using AR.Domain.Entities;
using AR.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Retentions.Commands.DeleteRetentionCollectionUnitPlan
{
    public class DeleteRetentionCollectionUnitPlanCommandHandler : IRequestHandler<DeleteRetentionCollectionUnitPlanCommand>
    {
        private readonly ApplicationDbContext _context;

        public DeleteRetentionCollectionUnitPlanCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRetentionCollectionUnitPlanCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RetentionCollectionUnitPlan.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(RetentionCollectionUnitPlan), request.Id);
            }

            _context.RetentionCollectionUnitPlan.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
