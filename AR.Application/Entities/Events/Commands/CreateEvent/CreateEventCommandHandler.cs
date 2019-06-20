using AR.Domain.Entities;
using AR.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AR.Application.Entities.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, string>
    {
        private readonly ApplicationDbContext _context;

        public CreateEventCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = new Event
            {
                Title = request.Title,
                Description = request.Description,
                Location = request.Location
            };
            _context.Events.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

    }
}
