
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AR.Application.Entities.Events.Queries.GetAllEvents;
using AR.Application.Entities.Events.Queries.GetEvent;
using AR.Application.Entities.Events.Commands.CreateEvent;
using AR.Application.Entities.Events.Commands.UpdateEvent;
using AR.Application.Entities.Events.Commands.DeleteEvent;
using AR.Application.Entities.Events.Models;

namespace AR.WebUI.Controllers
{
    public class EventsController : BaseController
    {

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<EventsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllEventsQuery()));
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> Get(string id)
        {
            return Ok(await Mediator.Send(new GetEventQuery { Id = id }));
        }

        // POST: api/Events
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreateEventCommand command)
        {

            var id = await Mediator.Send(command);

            return Ok(id);
        }

        // PUT: api/Events/5
        [HttpPut("{id}")]
        public async Task<ActionResult<EventDto>> Update([FromRoute] string id, [FromBody] UpdateEventCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteEventCommand { Id = id });

            return NoContent();
        }
    }
}
