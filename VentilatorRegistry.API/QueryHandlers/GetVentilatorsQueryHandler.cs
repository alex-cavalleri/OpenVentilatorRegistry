using Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VentilatorRegistry.API.Queries;
using VentilatorRegistry.API.QueryExecutors.Results;

namespace VentilatorRegistry.API.QueryHandlers
{
    public class GetVentilatorsQueryHandler : IQueryHandler<GetVentilatorsQuery, IEnumerable<GetVentilatorsQueryResult>>
    {
        private readonly IQueryExecutor<GetVentilatorsQuery, IEnumerable<GetVentilatorsQueryResult>> _queryExecutor;

        public GetVentilatorsQueryHandler(IQueryExecutor<GetVentilatorsQuery, IEnumerable<GetVentilatorsQueryResult>> queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task<IEnumerable<GetVentilatorsQueryResult>> Handle(GetVentilatorsQuery query, CancellationToken cancellationToken)
        {
            var result = await _queryExecutor.Execute(query);
            return result;
        }
    }
}
