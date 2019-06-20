using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AR.Application.Entities.Retentions.Queries.GetAllRetentionCollectionUnitPlans;
using AR.Application.Entities.Retentions.Queries.GetRetentionCollectionUnitPlan;
using AR.Application.Entities.Retentions.Commands.CreateRetentionCollectionUnitPlan;
using AR.Application.Entities.Retentions.Commands.UpdateRetentionCollectionUnitPlan;
using AR.Application.Entities.Retentions.Commands.DeleteRetentionCollectionUnitPlan;
using AR.Application.Entities.Retentions.Models;

namespace AR.WebSPA.Controllers
{
    public class RetentionCollectionUnitPlansController : BaseController
    {

        // GET: api/Retentions
        [HttpPost]
        public async Task<ActionResult<RetentionCollectionUnitPlansListViewModel>> GetAll([FromBody] GetAllRetentionCollectionUnitPlansQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        // GET: api/Retentions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RetentionCollectionUnitPlanDto>> Get(string id)
        {
            return Ok(await Mediator.Send(new GetRetentionCollectionUnitPlanQuery { Id = id }));
        }

        // POST: api/Retentions
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreateRetentionCollectionUnitPlanCommand command)
        {

            var id = await Mediator.Send(command);

            return Ok(id);
        }

        // PUT: api/Retentions/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RetentionCollectionUnitPlanDto>> Update([FromRoute] string id, [FromBody] UpdateRetentionCollectionUnitPlanCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE: api/Retentions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteRetentionCollectionUnitPlanCommand { Id = id });

            return NoContent();
        }
    }
}