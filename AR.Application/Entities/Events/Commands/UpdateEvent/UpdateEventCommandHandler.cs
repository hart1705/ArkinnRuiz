using AR.Application.Exceptions;
using AR.Domain.Entities;
using AR.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public UpdateEventCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Events.SingleAsync(c => c.Id == request.Id, cancellationToken);
            
            if (entity == null)
            {
                throw new NotFoundException(nameof(Event), request.Id);
            }
            
            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Location = request.Location;
           

            _context.Events.Update(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Title;

        }

    }
}
