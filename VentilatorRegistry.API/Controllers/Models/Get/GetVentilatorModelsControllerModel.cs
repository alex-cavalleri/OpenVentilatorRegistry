using System;

namespace VentilatorRegistry.API.Controllers.Models.Get
{
    public class GetVentilatorModelsControllerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset ProductionYear { get; set; }

    }
}
