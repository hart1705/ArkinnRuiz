using AR.Application.Exceptions;
using AR.Domain.Entities;
using AR.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Retentions.Commands.UpdateRetentionUnit
{
    public class UpdateRetentionUnitCommandHandler : IRequestHandler<UpdateRetentionUnitCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public UpdateRetentionUnitCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateRetentionUnitCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RetentionUnit.SingleAsync(c => c.Id == request.Id, cancellationToken);
            
            if (entity == null)
            {
                throw new NotFoundException(nameof(RetentionUnit), request.Id);
            }

            entity.Project = request.Project;
            entity.UnitNo = request.UnitNo;
            entity.Price = request.Price;
            entity.GP = request.GP;
            entity.GPValue = request.GPValue;
            entity.Price = request.Price;
            entity.GP = request.GP;
            entity.GPValue = request.GPValue;
            entity.UnitType = request.UnitType;

            _context.RetentionUnit.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Project;

        }

    }
}
