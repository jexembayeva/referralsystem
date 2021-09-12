using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReferralSystem.Domain.Dtos.Vehicles;
using ReferralSystem.Domain.Services.Vehicles;
using ReferralSystem.General.Services.Controllers;
using ReferralSystem.Models.Domain.Vehicles;
using Utils.Helpers;

namespace ReferralSystem.Api.Controllers
{
    [Route("[controller]")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehicleController(IVehicleService vehicleService)
        {
            vehicleService.ThrowIfNull(nameof(vehicleService));

            _vehicleService = vehicleService;
        }

        [HttpGet("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Vehicle>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var basePlatforms = await _vehicleService.GetAllAsync();
            return this.List(basePlatforms);
        }

        [HttpGet("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<Vehicle> GetByIdAsync([FromRoute] long id)
        {
            return await _vehicleService.GetByIdAsync(id);
        }

        [HttpPost("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<IActionResult> CreateAsync([FromBody] VehicleDto entity, CancellationToken cancellationToken)
        {
            await _vehicleService.InsertAsync(entity, cancellationToken);
            return Ok();
        }

        [HttpPut("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<IActionResult> UpdateAsync([FromBody] VehicleDto data, CancellationToken cancellationToken)
        {
            await _vehicleService.UpdateAsync(data, cancellationToken);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _vehicleService.DeleteAsync(id);
            return Ok();
        }
    }
}