using Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VentilatorRegistry.API.Queries;
using VentilatorRegistry.API.QueryExecutors.Results;

namespace VentilatorRegistry.API.QueryHandlers
{
    public class GetHospitalOrganizationsQueryHandler : IQueryHandler<GetHospitalOrganizationsQuery, IEnumerable<GetHospitalOrganizationsQueryResult>>
    {
        private readonly IQueryExecutor<GetHospitalOrganizationsQuery, IEnumerable<GetHospitalOrganizationsQueryResult>> _queryExecutor;

        public GetHospitalOrganizationsQueryHandler(IQueryExecutor<GetHospitalOrganizationsQuery, IEnumerable<GetHospitalOrganizationsQueryResult>> queryExecutor)
        {
            _queryExecutor = queryExecutor;
        }

        public async Task<IEnumerable<GetHospitalOrganizationsQueryResult>> Handle(GetHospitalOrganizationsQuery query, CancellationToken cancellationToken)
        {
            var result = await _queryExecutor.Execute(query);
            return result;
        }
    }
}
