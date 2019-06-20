using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Queries.GetAllRetentionWaivers
{
    public class GetAllRetentionWaiversQuery : IRequest<RetentionWaiversListViewModel>
    {
    }
}
