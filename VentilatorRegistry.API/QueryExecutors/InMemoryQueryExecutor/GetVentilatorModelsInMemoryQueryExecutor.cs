using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentilatorRegistry.API.Queries;
using VentilatorRegistry.API.QueryExecutors.Results;
using VentilatorRegistry.API.Repositories;

namespace VentilatorRegistry.API.QueryExecutors.InMemoryQueryExecutor
{
    public class GetVentilatorModelsInMemoryQueryExecutor : IQueryExecutor<GetVentilatorModelsQuery, IEnumerable<GetVentilatorModelsQueryResult>>
    {
        private readonly IVentilatorModelRepository _ventilatorRepsoitory;

        public GetVentilatorModelsInMemoryQueryExecutor(IVentilatorModelRepository ventilatorRepsoitory)
        {
            _ventilatorRepsoitory = ventilatorRepsoitory;
        }

        public Task<IEnumerable<GetVentilatorModelsQueryResult>> Execute(GetVentilatorModelsQuery query)
        {
            return Task.FromResult(_ventilatorRepsoitory.AllVentilatorModels.Select(v => new GetVentilatorModelsQueryResult
            {
                Id = v.Id,
                ProductionYear = v.ProductionYear,
                Name = v.Name
            }));
        }
    }
}
