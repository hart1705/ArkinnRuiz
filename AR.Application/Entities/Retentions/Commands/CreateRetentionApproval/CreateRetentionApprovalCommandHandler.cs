using AR.Domain.Entities;
using AR.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Retentions.Commands.CreateRetentionApproval
{
    public class CreateRetentionApprovalCommandHandler : IRequestHandler<CreateRetentionApprovalCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public CreateRetentionApprovalCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateRetentionApprovalCommand request, CancellationToken cancellationToken)
        {
            var entity = new RetentionApproval
            {
                Name = request.Name,
                Position = request.Position,
                Signiture = request.Signiture,
                ApprovalType = request.ApprovalType,
                RetentionId = request.RetentionId
            };
            _context.RetentionApproval.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }
}
