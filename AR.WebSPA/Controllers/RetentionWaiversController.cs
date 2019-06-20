using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AR.Application.Entities.Retentions.Queries.GetAllRetentionWaivers;
using AR.Application.Entities.Retentions.Queries.GetRetentionWaiver;
using AR.Application.Entities.Retentions.Commands.CreateRetentionWaiver;
using AR.Application.Entities.Retentions.Commands.UpdateRetentionWaiver;
using AR.Application.Entities.Retentions.Commands.DeleteRetentionWaiver;
using AR.Application.Entities.Retentions.Models;

namespace AR.WebSPA.Controllers
{
    public class RetentionWaiversController : BaseController
    {

        // GET: api/Retentions
        [HttpGet]
        public async Task<ActionResult<RetentionWaiversListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllRetentionWaiversQuery()));
        }

        // GET: api/Retentions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RetentionWaiverDto>> Get(string id)
        {
            return Ok(await Mediator.Send(new GetRetentionWaiverQuery { Id = id }));
        }

        // POST: api/Retentions
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreateRetentionWaiverCommand command)
        {

            var id = await Mediator.Send(command);

            return Ok(id);
        }

        // PUT: api/Retentions/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RetentionWaiverDto>> Update([FromRoute] string id, [FromBody] UpdateRetentionWaiverCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE: api/Retentions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteRetentionWaiverCommand { Id = id });

            return NoContent();
        }
    }
}