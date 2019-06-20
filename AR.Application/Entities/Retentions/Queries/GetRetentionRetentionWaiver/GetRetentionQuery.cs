﻿using AR.Application.Entities.Retentions.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Queries.GetRetentionWaiver
{
    public class GetRetentionWaiverQuery : IRequest<RetentionWaiverDto>
    {
        public string Id { get; set; }
    }
}
