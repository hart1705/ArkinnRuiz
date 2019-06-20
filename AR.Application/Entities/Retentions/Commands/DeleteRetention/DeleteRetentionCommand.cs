using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Commands.DeleteRetention
{
    public class DeleteRetentionCommand : IRequest
    {
        public string Id { get; set; }
    }
}
