using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Commands.DeleteRetentionUnit
{ 
    public class DeleteRetentionUnitCommand : IRequest
    {
        public string Id { get; set; }
    }
}
