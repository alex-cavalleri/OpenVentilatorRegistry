using MediatR;
using Shared;

namespace VentilatorRegistry.API.Commands
{
    public class CreateVentilatorCommand : ICommand, IRequest<int>
    {
        public int IdModel { get; set; }
        public string SerialNumber { get; set; }
        public int IdUser { get; set; }
    }
}
