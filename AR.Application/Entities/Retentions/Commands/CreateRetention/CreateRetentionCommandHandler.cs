using AR.Domain.Entities;
using AR.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Retentions.Commands.CreateRetention
{
    public class CreateRetentionCommandHandler : IRequestHandler<CreateRetentionCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public CreateRetentionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateRetentionCommand request, CancellationToken cancellationToken)
        {
            var entity = new Retention
            {
                ClientName = request.ClientName,
                CustomerID = request.CustomerID,
                ContactNumber = request.ContactNumber,
                CurrentProject = request.CurrentProject,
                CurrentUnitNumber = request.CurrentUnitNumber,
                Price = request.Price,
                GP = request.GP,
                GPValue = request.GPValue,
                SIMAH = request.SIMAH,
                TypeOfCounterOffers = request.TypeOfCounterOffers,
                Description = request.Description,
                VAS = request.VAS,
                RefNo = request.RefNo
            };
            _context.Retentions.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }
}
