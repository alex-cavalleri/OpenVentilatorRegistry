using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentilatorRegistry.API.Queries;
using VentilatorRegistry.API.QueryExecutors.Results;
using VentilatorRegistry.API.Repositories;

namespace VentilatorRegistry.API.QueryExecutors.InMemoryQueryExecutor
{
    public class GetVentilatorsInMemoryQueryExecutor : IQueryExecutor<GetVentilatorsQuery, IEnumerable<GetVentilatorsQueryResult>>
    {
        private readonly IVentilatorRepository _ventilatorRepsoitory;

        public GetVentilatorsInMemoryQueryExecutor(IVentilatorRepository ventilatorRepsoitory)
        {
            _ventilatorRepsoitory = ventilatorRepsoitory;
        }

        public Task<IEnumerable<GetVentilatorsQueryResult>> Execute(GetVentilatorsQuery query)
        {
            return Task.FromResult(_ventilatorRepsoitory.AllVentilators.Select(v => new GetVentilatorsQueryResult
            {
                Id = v.Id,
                ModelName = v.Model.Name,
                SerialNumber = v.SerialNumber,
                StateCode = v.State.Code,
                StateDescription = v.State.Description
            }));
        }
    }
}
