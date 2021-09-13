using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReferralSystem.Domain.Dtos.Bases;
using ReferralSystem.Domain.Services.Bases;
using ReferralSystem.General.Services.Controllers;
using ReferralSystem.Models.Domain.Bases;
using Utils.Helpers;

namespace ReferralSystem.Api.Controllers
{
    [Route("[controller]")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class VehicleBaseController : ControllerBase
    {
        private readonly IVehicleBaseService _vehicleBaseService;

        public VehicleBaseController(IVehicleBaseService vehicleBaseService)
        {
            vehicleBaseService.ThrowIfNull(nameof(vehicleBaseService));

            _vehicleBaseService = vehicleBaseService;
        }

        [HttpGet("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VehicleBase>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var basePlatforms = await _vehicleBaseService.GetAllAsync();
            return this.List(basePlatforms);
        }

        [HttpGet("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            var basePlatform = await _vehicleBaseService.GetByIdAsync(id);
            return this.Get(basePlatform);
        }

        [HttpPost("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<IActionResult> CreateAsync([FromBody] VehicleBaseDto entity, CancellationToken cancellationToken)
        {
            await _vehicleBaseService.InsertAsync(entity, cancellationToken);
            return Ok();
        }

        [HttpPut("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<IActionResult> UpdateAsync([FromBody] VehicleBaseDto data, CancellationToken cancellationToken)
        {
            await _vehicleBaseService.UpdateAsync(data, cancellationToken);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _vehicleBaseService.DeleteAsync(id);
            return Ok();
        }
    }
}