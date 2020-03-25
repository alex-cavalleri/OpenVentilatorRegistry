using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VentilatorRegistry.API.Commands;
using VentilatorRegistry.API.Controllers.Models.Get;
using VentilatorRegistry.API.Controllers.Models.Post;
using VentilatorRegistry.API.Queries;

namespace VentilatorRegistry.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentilatorModelsController : ControllerBase
    {
        private readonly ILogger<VentilatorModelsController> _logger;
        private readonly IMediator _mediatR;

        public VentilatorModelsController(IMediator mediatR, ILogger<VentilatorModelsController> logger)
        {
            _logger = logger;
            _mediatR = mediatR;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetVentilatorModelsControllerModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var result = await _mediatR.Send(new GetVentilatorModelsQuery());
            return Ok(result.Select(r => new GetVentilatorModelsControllerModel
            {
                Id = r.Id,
                Name = r.Name,
                ProductionYear = r.ProductionYear
            }));
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] PostVentilatorModelControllerModel postVentilatorModel)
        {
            var result = await _mediatR.Send(new CreateVentilatorModelCommand
            {
                Name = postVentilatorModel.ModelName,
                ProductionYear = postVentilatorModel.ProductionYear,
            });
            return Ok(result);
        }
    }
}
