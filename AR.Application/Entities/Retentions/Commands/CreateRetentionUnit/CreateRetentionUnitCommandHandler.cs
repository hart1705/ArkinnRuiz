using AR.Domain.Entities;
using AR.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Retentions.Commands.CreateRetentionUnit
{
    public class CreateRetentionUnitCommandHandler : IRequestHandler<CreateRetentionUnitCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public CreateRetentionUnitCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateRetentionUnitCommand request, CancellationToken cancellationToken)
        {
            var entity = new RetentionUnit
            {
                Project = request.Project,
                UnitNo = request.UnitNo,
                Price = request.Price,
                GP = request.GP,
                GPValue = request.GPValue,
                RetentionId = request.RetentionId,
                UnitType = request.UnitType
            };
            _context.RetentionUnit.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }
}
