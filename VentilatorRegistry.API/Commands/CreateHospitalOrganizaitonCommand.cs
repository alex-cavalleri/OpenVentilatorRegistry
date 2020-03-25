using MediatR;
using Shared;

namespace VentilatorRegistry.API.Commands
{
    public class CreateHospitalOrganizationCommand : ICommand, IRequest<int>
    {
        public string Name { get; set; }
    }
}
