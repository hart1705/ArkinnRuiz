using AR.Application.Exceptions;
using AR.Domain.Entities;
using AR.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Retentions.Commands.UpdateRetentionWaiver
{
    public class UpdateRetentionWaiverCommandHandler : IRequestHandler<UpdateRetentionWaiverCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public UpdateRetentionWaiverCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateRetentionWaiverCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RetentionWaiver.SingleAsync(c => c.Id == request.Id, cancellationToken);
            
            if (entity == null)
            {
                throw new NotFoundException(nameof(RetentionWaiver), request.Id);
            }

            entity.InstallementAmount = request.InstallementAmount;
            entity.ServiceChargeAmount = request.ServiceChargeAmount;
            entity.BearingCost = request.BearingCost;
            
            _context.RetentionWaiver.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;

        }

    }
}
