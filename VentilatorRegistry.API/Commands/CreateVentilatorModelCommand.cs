using MediatR;
using Shared;
using System;

namespace VentilatorRegistry.API.Commands
{
    public class CreateVentilatorModelCommand : ICommand, IRequest<int>
    {
        public string Name { get; set; }
        public DateTimeOffset ProductionYear { get; set; }
    }
}
