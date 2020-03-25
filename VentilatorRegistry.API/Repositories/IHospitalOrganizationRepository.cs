using System.Collections.Generic;
using VentilatorRegistry.HospitalAggregate;

namespace VentilatorRegistry.API.Repositories
{
    public interface IHospitalOrganizationRepository
    {
        IEnumerable<HospitalOrganization> AllHospitalOrganizations { get; }
        HospitalOrganization GetById(int id);
        HospitalOrganization Save(HospitalOrganization hospital);
        HospitalOrganization Update(HospitalOrganization organization);
    }
}
