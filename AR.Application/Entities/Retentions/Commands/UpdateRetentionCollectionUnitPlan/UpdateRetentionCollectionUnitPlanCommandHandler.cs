using AR.Application.Exceptions;
using AR.Domain.Entities;
using AR.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Retentions.Commands.UpdateRetentionCollectionUnitPlan
{
    public class UpdateRetentionCollectionUnitPlanCommandHandler : IRequestHandler<UpdateRetentionCollectionUnitPlanCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public UpdateRetentionCollectionUnitPlanCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateRetentionCollectionUnitPlanCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RetentionCollectionUnitPlan.SingleAsync(c => c.Id == request.Id, cancellationToken);
            
            if (entity == null)
            {
                throw new NotFoundException(nameof(RetentionCollectionUnitPlan), request.Id);
            }

            entity.SoldDate = request.SoldDate;
            entity.ReservedDate = request.ReservedDate;
            entity.PaymentPlan = request.PaymentPlan;
            entity.FirstInstallment = request.FirstInstallment;
            entity.LastInstallment = request.LastInstallment;
            entity.NoSettledInstallments = request.NoSettledInstallments;
            entity.NoOfInstallments = request.NoOfInstallments;
            entity.CollectedAmount = request.CollectedAmount;
            entity.TotalCollectedAmount = request.TotalCollectedAmount;
            entity.CollectedPercent = request.CollectedPercent;
            entity.DueAmount = request.DueAmount;
            entity.RemainingAmount = request.RemainingAmount;
            entity.UnitType = request.UnitType;

            _context.RetentionCollectionUnitPlan.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.PaymentPlan;

        }

    }
}
