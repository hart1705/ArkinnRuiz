using AR.Domain.Entities;
using AR.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Retentions.Commands.CreateRetentionCollectionUnitPlan
{
    public class CreateRetentionCollectionUnitPlanCommandHandler : IRequestHandler<CreateRetentionCollectionUnitPlanCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public CreateRetentionCollectionUnitPlanCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateRetentionCollectionUnitPlanCommand request, CancellationToken cancellationToken)
        {
            var entity = new RetentionCollectionUnitPlan
            {
                SoldDate = request.SoldDate.Value.AddHours(8),
                ReservedDate = request.ReservedDate,
                PaymentPlan = request.PaymentPlan,
                FirstInstallment = request.FirstInstallment.Value.AddHours(8),
                LastInstallment = request.LastInstallment.Value.AddHours(8),
                NoSettledInstallments = request.NoSettledInstallments,
                NoOfInstallments = request.NoOfInstallments,
                CollectedAmount = request.CollectedAmount,
                TotalCollectedAmount = request.TotalCollectedAmount,
                CollectedPercent = request.CollectedPercent,
                DueAmount = request.DueAmount,
                RemainingAmount = request.RemainingAmount,
                UnitType = request.UnitType,
                RetentionId = request.RetentionId
            };
            _context.RetentionCollectionUnitPlan.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }
}
