using AR.Application.Exceptions;
using AR.Domain.Entities;
using AR.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Retentions.Commands.UpdateRetentionApproval
{
    public class UpdateRetentionApprovalCommandHandler : IRequestHandler<UpdateRetentionApprovalCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public UpdateRetentionApprovalCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateRetentionApprovalCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RetentionApproval.SingleAsync(c => c.Id == request.Id, cancellationToken);
            
            if (entity == null)
            {
                throw new NotFoundException(nameof(RetentionApproval), request.Id);
            }

            entity.Name = request.Name;
            entity.Position = request.Position;
            entity.Signiture = request.Signiture;
            entity.ApprovalType = request.ApprovalType;

            _context.RetentionApproval.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Name;

        }

    }
}
