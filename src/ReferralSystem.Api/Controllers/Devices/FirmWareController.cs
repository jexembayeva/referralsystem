using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReferralSystem.Domain.Dtos.Devices;
using ReferralSystem.Domain.Services.Devices;
using ReferralSystem.General.Services.Controllers;
using ReferralSystem.Models.Domain.Devices;
using Utils.Helpers;

namespace ReferralSystem.Api.Controllers.Devices
{
    [Route("[controller]")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class FirmWareController : ControllerBase
    {
        private readonly IFirmWareService _firmWareService;

        public FirmWareController(IFirmWareService firmWareService)
        {
            firmWareService.ThrowIfNull(nameof(firmWareService));

            _firmWareService = firmWareService;
        }

        [HttpGet("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<FirmWare>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllAsync()
        {
            var firmWares = await _firmWareService.GetAllAsync();
            return this.List(firmWares);
        }

        [HttpGet("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            var firmWare = await _firmWareService.GetByIdAsync(id);
            return this.Get(firmWare);
        }

        [HttpPost("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateAsync([FromBody] FirmWareDto entity)
        {
            await _firmWareService.InsertAsync(entity);
            return Ok();
        }

        [HttpPut("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAsync([FromBody] FirmWareDto data)
        {
            await _firmWareService.UpdateAsync(data);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _firmWareService.DeleteAsync(id);
            return Ok();
        }
    }
}