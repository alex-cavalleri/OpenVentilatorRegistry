using Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VentilatorRegistry.API.Commands;
using VentilatorRegistry.API.Repositories;
using VentilatorRegistry.HospitalAggregate;

namespace VentilatorRegistry.API.CommandHandlers
{
    public class CreateHospitalOrganizationCommandHandler : ICommandHandler<CreateHospitalOrganizationCommand, int>
    {
        private readonly IHospitalOrganizationRepository _hospitalOrganizationRepository;

        public CreateHospitalOrganizationCommandHandler(IHospitalOrganizationRepository hospitalOrganizationRepository)
        {
            _hospitalOrganizationRepository = hospitalOrganizationRepository;
        }

        public Task<int> Handle(CreateHospitalOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organization = new HospitalOrganization(request.Name);
            organization = _hospitalOrganizationRepository.Save(organization);
            return Task.FromResult(organization.Id);
        }
    }
}
