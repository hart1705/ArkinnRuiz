using AR.Application.Entities.Retentions.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Queries.GetRetention
{
    public class GetRetentionQuery : IRequest<RetentionDto>
    {
        public string Id { get; set; }
    }
}
