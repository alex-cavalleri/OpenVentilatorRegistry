using Shared;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VentilatorRegistry.API.Commands;
using VentilatorRegistry.API.Repositories;
using VentilatorRegistry.VentilatorAggregate;

namespace VentilatorRegistry.API.CommandHandlers
{
    public class CreateVentilatorCommandHandler : ICommandHandler<CreateVentilatorCommand, int>
    {
        private readonly IVentilatorRepository _ventilatorRepsoitory;
        private readonly IVentilatorModelRepository _ventilatorModelRepsoitory;

        public CreateVentilatorCommandHandler(IVentilatorRepository ventilatorRepsoitory,
                                              IVentilatorModelRepository ventilatorModelRepsoitory)
        {
            _ventilatorRepsoitory = ventilatorRepsoitory;
            _ventilatorModelRepsoitory = ventilatorModelRepsoitory;
        }

        public Task<int> Handle(CreateVentilatorCommand request, CancellationToken cancellationToken)
        {
            var model = _ventilatorModelRepsoitory.GetById(request.IdModel);
            var ventilator = new Ventilator(model, request.SerialNumber, request.IdUser);
            ventilator = _ventilatorRepsoitory.Save(ventilator);
            return Task.FromResult(ventilator.Id);
        }
    }
}
