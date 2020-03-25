using Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VentilatorRegistry.API.Queries;
using VentilatorRegistry.API.QueryExecutors.Results;

namespace VentilatorRegistry.API.QueryHandlers
{
    public class GetVentilatorModelsQueryHandler : IQueryHandler<GetVentilatorModelsQuery, IEnumerable<GetVentilatorModelsQueryResult>>
    {
        private readonly IQueryExecutor<GetVentilatorModelsQuery, IEnumerable<GetVentilatorModelsQueryResult>> _queryExecutor;

        public GetVentilatorModelsQueryHandler(IQueryExecutor<GetVentilatorModelsQuery, IEnumerable<GetVentilatorModelsQueryResult>> queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task<IEnumerable<GetVentilatorModelsQueryResult>> Handle(GetVentilatorModelsQuery query, CancellationToken cancellationToken)
        {
            var result = await _queryExecutor.Execute(query);
            return result;
        }
    }
}
