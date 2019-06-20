using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AR.Application.Entities.Retentions.Queries.GetAllRetentionUnits;
using AR.Application.Entities.Retentions.Queries.GetRetentionUnit;
using AR.Application.Entities.Retentions.Commands.CreateRetentionUnit;
using AR.Application.Entities.Retentions.Commands.UpdateRetentionUnit;
using AR.Application.Entities.Retentions.Commands.DeleteRetentionUnit;
using AR.Application.Entities.Retentions.Models;

namespace AR.WebSPA.Controllers
{
    public class RetentionUnitsController : BaseController
    {

        // GET: api/Retentions
        [HttpPost]
        public async Task<ActionResult<RetentionUnitsListViewModel>> GetAll([FromBody] GetAllRetentionUnitsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        // GET: api/Retentions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RetentionUnitDto>> Get(string id)
        {
            return Ok(await Mediator.Send(new GetRetentionUnitQuery { Id = id }));
        }

        // POST: api/Retentions
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreateRetentionUnitCommand command)
        {

            var id = await Mediator.Send(command);

            return Ok(id);
        }

        // PUT: api/Retentions/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RetentionUnitDto>> Update([FromRoute] string id, [FromBody] UpdateRetentionUnitCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE: api/Retentions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteRetentionUnitCommand { Id = id });

            return NoContent();
        }
    }
}