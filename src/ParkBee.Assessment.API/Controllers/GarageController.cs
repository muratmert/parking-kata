using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ParkBee.Assessment.API.Configuration;
using ParkBee.Assessment.Application.Garages;

namespace ParkBee.Assessment.API.Controllers
{
    [Route("api/garages")]
    public class GarageController : Controller
    {
        private readonly IMediator _mediator;

        public GarageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// See garage details.
        /// </summary>
        [Route("")]
        [HttpGet("{garageId}")]
        [Authorize]
        [ProducesResponseType(typeof(List<GarageDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> GetGarageDetails(int garageId)
        {
            List<GarageDto> garages = await _mediator.Send(new GetGarageByIdQuery(garageId));
            return Ok(garages);
        }

        /// <summary>
        /// Refresh garage status.
        /// </summary>
        [Route("refresh")]
        [HttpPost("{garageId}")]
        [Authorize]
        [ProducesResponseType(typeof(List<GarageDto>), (int) HttpStatusCode.OK)]
        public async Task<IActionResult> RefreshGarage([FromRoute] int garageId)
        {
            List<GarageDto> garages = await _mediator.Send(new GarageRefreshCommand(garageId));
            return Ok(garages);
        }
    }
}