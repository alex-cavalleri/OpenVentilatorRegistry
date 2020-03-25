using Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VentilatorRegistry.API.Queries;
using VentilatorRegistry.API.QueryExecutors.Results;

namespace VentilatorRegistry.API.QueryHandlers
{
    public class GetHospitalsQueryHandler : IQueryHandler<GetHospitalsQuery, IEnumerable<GetHospitalsQueryResult>>
    {
        private readonly IQueryExecutor<GetHospitalsQuery, IEnumerable<GetHospitalsQueryResult>> _queryExecutor;

        public GetHospitalsQueryHandler(IQueryExecutor<GetHospitalsQuery, IEnumerable<GetHospitalsQueryResult>> queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task<IEnumerable<GetHospitalsQueryResult>> Handle(GetHospitalsQuery query, CancellationToken cancellationToken)
        {
            var result = await _queryExecutor.Execute(query);
            return result;
        }
    }
}
