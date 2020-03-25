using System.Collections.Generic;
using System.Linq;
using VentilatorRegistry.HospitalAggregate;

namespace VentilatorRegistry.API.Repositories
{
    public class HospitalOrganizationInMemoryRepository : IHospitalOrganizationRepository
    {
        public IEnumerable<HospitalOrganization> AllHospitalOrganizations => _AllHospitalOrganizations.AsEnumerable();
        private List<HospitalOrganization> _AllHospitalOrganizations { get; set; }
        private int lastId = 0;
        private readonly object _lock = new object();

        public HospitalOrganizationInMemoryRepository()
        {
            _AllHospitalOrganizations = new List<HospitalOrganization>();
        }

        public HospitalOrganization GetById(int id)
        {
            return AllHospitalOrganizations.FirstOrDefault(h => h.Id == id);
        }

        public HospitalOrganization Save(HospitalOrganization hospitalOrganization)
        {
            lock (_lock)
            {
                hospitalOrganization.SetId(++lastId);
            }

            _AllHospitalOrganizations.Add(hospitalOrganization);
            return hospitalOrganization;
        }

        public HospitalOrganization Update(HospitalOrganization organization)
        {
            var repositoryOrganization = GetById(organization.Id);
            repositoryOrganization = organization;
            return repositoryOrganization;
        }
    }
}
