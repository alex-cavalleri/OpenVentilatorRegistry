using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentilatorRegistry.API.Queries;
using VentilatorRegistry.API.QueryExecutors.Results;
using VentilatorRegistry.API.Repositories;

namespace VentilatorRegistry.API.QueryExecutors.InMemoryQueryExecutor
{
    public class GetHospitalsInMemoryQueryExecutor : IQueryExecutor<GetHospitalsQuery, IEnumerable<GetHospitalsQueryResult>>
    {
        private readonly IHospitalOrganizationRepository _hospitalRepository;

        public GetHospitalsInMemoryQueryExecutor(IHospitalOrganizationRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;
        }

        public Task<IEnumerable<GetHospitalsQueryResult>> Execute(GetHospitalsQuery query)
        {
            return Task.FromResult(_hospitalRepository.AllHospitalOrganizations.SelectMany(o =>
                o.Hospitals.Select(h => new GetHospitalsQueryResult
                {
                    Id = h.Id,
                    NationalProviderIdentifier = h.NationalProviderIdentifier,
                    Name = h.Name,
                    IsVerified = h.IsVerified
                })));
        }
    }
}
