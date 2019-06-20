using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace AR.Application.Entities.Retentions.Queries.GetAllRetentions
{
    public class GetAllRetentionsQuery : IRequest<RetentionsListViewModel>
    {
    }
}
