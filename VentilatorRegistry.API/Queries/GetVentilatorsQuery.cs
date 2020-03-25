using MediatR;
using Shared;
using System.Collections.Generic;
using VentilatorRegistry.API.QueryExecutors.Results;

namespace VentilatorRegistry.API.Queries
{
    public class GetVentilatorsQuery : IQuery, IRequest<IEnumerable<GetVentilatorsQueryResult>>
    {
    }
}
