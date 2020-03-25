using Shared;
using System;
using System.Threading;
using System.Threading.Tasks;
using VentilatorRegistry.API.Commands;
using VentilatorRegistry.API.Repositories;
using VentilatorRegistry.VentilatorAggregate;

namespace VentilatorRegistry.API.CommandHandlers
{
    public class CreateVentilatorModelCommandHandler : ICommandHandler<CreateVentilatorModelCommand, int>
    {
        private readonly IVentilatorModelRepository _ventilatorModelRepository;

        public CreateVentilatorModelCommandHandler(IVentilatorModelRepository ventilatorModelRepository)
        {
            _ventilatorModelRepository = ventilatorModelRepository;
        }

        public Task<int> Handle(CreateVentilatorModelCommand request, CancellationToken cancellationToken)
        {
            var model = new VentilatorModel(request.Name, request.ProductionYear);
            model = _ventilatorModelRepository.Save(model);
            return Task.FromResult(model.Id);
        }
    }
}
