using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VentilatorRegistry.API.Queries;
using VentilatorRegistry.API.QueryExecutors.Results;
using VentilatorRegistry.API.Repositories;

namespace VentilatorRegistry.API.QueryExecutors.InMemoryQueryExecutor
{
    public class GetHospitalOrganizationsInMemoryQueryExecutor : IQueryExecutor<GetHospitalOrganizationsQuery, IEnumerable<GetHospitalOrganizationsQueryResult>>
    {
        private readonly IHospitalOrganizationRepository _hospitalOrganizationRepository;

        public GetHospitalOrganizationsInMemoryQueryExecutor(IHospitalOrganizationRepository hospitalOrganizationRepository)
        {
            _hospitalOrganizationRepository = hospitalOrganizationRepository;
        }

        public Task<IEnumerable<GetHospitalOrganizationsQueryResult>> Execute(GetHospitalOrganizationsQuery query)
        {
            return Task.FromResult(_hospitalOrganizationRepository.AllHospitalOrganizations.Select(o => new GetHospitalOrganizationsQueryResult
            {
                Id = o.Id,
                Name = o.Name,
                TotalHospitals = o.Hospitals.Count
            }));
        }
    }
}
