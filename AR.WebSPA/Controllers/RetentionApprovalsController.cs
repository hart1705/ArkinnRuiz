using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AR.Application.Entities.Retentions.Queries.GetAllRetentionApprovals;
using AR.Application.Entities.Retentions.Queries.GetRetentionApproval;
using AR.Application.Entities.Retentions.Commands.CreateRetentionApproval;
using AR.Application.Entities.Retentions.Commands.UpdateRetentionApproval;
using AR.Application.Entities.Retentions.Commands.DeleteRetentionApproval;
using AR.Application.Entities.Retentions.Models;
using AR.Domain.Helpers;
using AR.Application.Helpers;

namespace AR.WebSPA.Controllers
{
    public class RetentionApprovalsController : BaseController
    {

        // GET: api/Retentions
        [HttpPost]
        public async Task<ActionResult<RetentionApprovalsListViewModel>> GetAll([FromBody] GetAllRetentionApprovalsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        // GET: api/Retentions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RetentionApprovalDto>> Get(string id)
        {
            return Ok(await Mediator.Send(new GetRetentionApprovalQuery { Id = id }));
        }

        // POST: api/Retentions
        [HttpPost]
        public async Task<ActionResult<string>> Create([FromBody] CreateRetentionApprovalCommand command)
        {

            var id = await Mediator.Send(command);

            return Ok(id);
        }

        // PUT: api/Retentions/5
        [HttpPut("{id}")]
        public async Task<ActionResult<RetentionApprovalDto>> Update([FromRoute] string id, [FromBody] UpdateRetentionApprovalCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE: api/Retentions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await Mediator.Send(new DeleteRetentionApprovalCommand { Id = id });

            return NoContent();
        }
    }
}