using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VentilatorRegistry.API.Commands;
using VentilatorRegistry.API.Controllers.Models;
using VentilatorRegistry.API.Controllers.Models.Get;
using VentilatorRegistry.API.Queries;

namespace VentilatorRegistry.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HospitalOrganizationsController : Controller
    {
        private readonly ILogger<HospitalOrganizationsController> _logger;
        private readonly IMediator _mediatR;

        public HospitalOrganizationsController(IMediator mediatR, ILogger<HospitalOrganizationsController> logger)
        {
            _logger = logger;
            _mediatR = mediatR;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetHospitalOrganizationsControllerModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get()
        {
            var result = await _mediatR.Send(new GetHospitalOrganizationsQuery());
            return Ok(result.Select(r => new GetHospitalOrganizationsControllerModel
            {
                Id = r.Id,
                Name = r.Name
            }));
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post([FromBody] PostHospitalOrganizationControllerModel postHospitalOrganization)
        {
            var result = await _mediatR.Send(new CreateHospitalOrganizationCommand
            {
                Name = postHospitalOrganization.Name
            });
            return Ok(result);
        }

        [HttpGet("hospitals")]
        [ProducesResponseType(typeof(IEnumerable<GetHospitalsControllerModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetHospitals()
        {
            var result = await _mediatR.Send(new GetHospitalsQuery());
            return Ok(result.Select(r => new GetHospitalsControllerModel
            {
                Id = r.Id,
                IsVerified = r.IsVerified,
                NationalProviderIdentifier = r.NationalProviderIdentifier,
                Name = r.Name
            }));
        }

        [HttpPost("{idOrganization}/hospitals")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PostHospital(int idOrganization, [FromBody] PostHospitalControllerModel postHospital)
        {
            var result = await _mediatR.Send(new CreateHospitalCommand
            {
                City = postHospital.City,
                Country = postHospital.Country,
                IdOrganization = idOrganization,
                NationalProviderIdentifier = postHospital.NationalProviderIdentifier,
                Name = postHospital.Name,
                State = postHospital.State,
                StreetAddress = postHospital.StreetAddress
            });

            return Ok(result);
        }
    }
}
