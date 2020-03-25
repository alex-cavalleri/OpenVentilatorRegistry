using MediatR;
using Shared;

namespace VentilatorRegistry.API.Commands
{
    public class CreateHospitalCommand : ICommand, IRequest<int>
    {
        public string Name { get; set; }
        public int NationalProviderIdentifier { get; set; }
        public int IdOrganization { get; set; }
        public string StreetAddress { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string Country { get;  set; }
    }
}
