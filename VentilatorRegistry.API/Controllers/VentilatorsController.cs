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
    public class VentilatorsController : ControllerBase
    {
        private readonly ILogger<VentilatorsController> _logger;
        private readonly IMediator _mediatR;

        public VentilatorsController(IMediator mediatR, ILogger<VentilatorsController> logger)
        {
            _logger = logger;
            _mediatR = mediatR;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetVentilatorsControllerModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var result = await _mediatR.Send(new GetVentilatorsQuery());
            return Ok(result.Select(r => new GetVentilatorsControllerModel
            {
                Id = r.Id,
                StateDescription = r.StateDescription,
                ModelName = r.ModelName,
                SerialNumber = r.SerialNumber,
                StateCode = r.StateCode
            }));
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] PostVentilatorControllerModel postVentilator)
        {
            var result = await _mediatR.Send(new CreateVentilatorCommand
            {
                IdModel = postVentilator.IdModel,
                SerialNumber = postVentilator.SerialNumber,
                IdUser = 1 //TODO: temporary, remove when AAA is done
            });
            return Ok(result);
        }
    }
}
