using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AR.Application.Entities.Retentions.Queries.GetAllRetentions;
using AR.Application.Entities.Retentions.Queries.GetRetention;
using AR.Application.Entities.Retentions.Commands.CreateRetention;
using AR.Application.Entities.Retentions.Commands.UpdateRetention;
using AR.Application.Entities.Retentions.Commands.DeleteRetention;
using AR.Application.Entities.Retentions.Models;

namespace AR.WebSPA.Controllers
{
    public class RetentionsController : BaseController
    {

        // GET: api/Retentions
        [HttpGet]
        public async Task<ActionResult<RetentionsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllRetentionsQuery()));
        }

        // GET: api/Retentions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RetentionDto>> Get(string id)
        {
            return Ok(await Mediator.Send(new GetRetentionQuery { Id = id }));
        }

        // POST: api/Retentions
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreateRetentionCommand command)
        {

            var id = await Mediator.Send(command);

            return Ok(id);
        }

        // PUT: api/Retentions/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RetentionDto>> Update([FromRoute] string id, [FromBody] UpdateRetentionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE: api/Retentions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteRetentionCommand { Id = id });

            return NoContent();
        }
    }
}