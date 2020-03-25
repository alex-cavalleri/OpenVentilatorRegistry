using System;

namespace VentilatorRegistry.API.Controllers.Models.Post
{
    public class PostVentilatorModelControllerModel
    {
        public string ModelName { get; set; }
        public DateTimeOffset ProductionYear { get; set; }
    }
}
