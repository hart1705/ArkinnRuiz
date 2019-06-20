using AR.Application.Exceptions;
using AR.Domain.Entities;
using AR.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Retentions.Commands.UpdateRetention
{
    public class UpdateRetentionCommandHandler : IRequestHandler<UpdateRetentionCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public UpdateRetentionCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateRetentionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Retentions.SingleAsync(c => c.Id == request.Id, cancellationToken);
            
            if (entity == null)
            {
                throw new NotFoundException(nameof(Retention), request.Id);
            }

            entity.ClientName = request.ClientName;
            entity.CustomerID = request.CustomerID;
            entity.ContactNumber = request.ContactNumber;
            entity.CurrentProject = request.CurrentProject;
            entity.CurrentUnitNumber = request.CurrentUnitNumber;
            entity.Price = request.Price;
            entity.GP = request.GP;
            entity.GPValue = request.GPValue;
            entity.SIMAH = request.SIMAH;
            entity.TypeOfCounterOffers = request.TypeOfCounterOffers;
            entity.Description = request.Description;
            entity.VAS = request.VAS;
            entity.RefNo = request.RefNo;

            _context.Retentions.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.ClientName;

        }

    }
}
