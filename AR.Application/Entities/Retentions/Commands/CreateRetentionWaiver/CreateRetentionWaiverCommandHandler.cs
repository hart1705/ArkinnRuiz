using AR.Domain.Entities;
using AR.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Retentions.Commands.CreateRetentionWaiver
{
    public class CreateRetentionWaiverCommandHandler : IRequestHandler<CreateRetentionWaiverCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public CreateRetentionWaiverCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateRetentionWaiverCommand request, CancellationToken cancellationToken)
        {
            var entity = new RetentionWaiver
            {
                InstallementAmount = request.InstallementAmount,
                ServiceChargeAmount = request.ServiceChargeAmount,
                BearingCost = request.BearingCost,
                RetentionId = request.RetentionId
            };
            _context.RetentionWaiver.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }
}
