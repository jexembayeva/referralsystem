using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReferralSystem.Domain.Dtos.VehicleBases;
using ReferralSystem.Domain.Services.VehicleBases;
using ReferralSystem.General.Services.Controllers;
using ReferralSystem.Models.Domain.VehicleBases;
using Utils.Helpers;

namespace ReferralSystem.Api.Controllers.VehicleBases
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
        public async Task<IActionResult> GetAllAsync()
        {
            var basePlatforms = await _vehicleBaseService.GetAllAsync();
            return this.List(basePlatforms);
        }

        [HttpGet("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            var basePlatform = await _vehicleBaseService.GetByIdAsync(id);
            return this.Get(basePlatform);
        }

        [HttpPost("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateAsync([FromBody] VehicleBaseDto entity)
        {
            await _vehicleBaseService.InsertAsync(entity);
            return Ok();
        }

        [HttpPut("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAsync([FromBody] VehicleBaseDto data)
        {
            await _vehicleBaseService.UpdateAsync(data);
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