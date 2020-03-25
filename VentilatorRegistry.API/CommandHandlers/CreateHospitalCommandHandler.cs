using Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VentilatorRegistry.API.Commands;
using VentilatorRegistry.API.Repositories;

namespace VentilatorRegistry.API.CommandHandlers
{
    public class CreateHospitalCommandHandler : ICommandHandler<CreateHospitalCommand, int>
    {
        private readonly IHospitalOrganizationRepository _hospitalOrganizationRepository;

        public CreateHospitalCommandHandler(IHospitalOrganizationRepository hospitalOrganizationRepository)
        {
            _hospitalOrganizationRepository = hospitalOrganizationRepository;
        }

        public Task<int> Handle(CreateHospitalCommand request, CancellationToken cancellationToken)
        {
            var organization = _hospitalOrganizationRepository.GetById(request.IdOrganization);
            if (organization == null)
            {
                throw new KeyNotFoundException($"organization {request.IdOrganization} not found");
            }

            var hospital = organization.AddHospital(request.Name, request.NationalProviderIdentifier, request.StreetAddress, request.City, request.State, request.Country);
            _hospitalOrganizationRepository.Update(organization);
            return Task.FromResult(hospital.Id);
        }
    }
}
