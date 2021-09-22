using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Domain.Services.Routes.LadStops;
using ReferralSystem.General.Services.Controllers;
using ReferralSystem.Models.Domain.Routes;
using Utils.Helpers;

namespace ReferralSystem.Api.Controllers.Routes
{
    [Route("[controller]")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class LadStopController : ControllerBase
    {
        private readonly ILadStopService _ladStopService;

        public LadStopController(ILadStopService ladStopService)
        {
            ladStopService.ThrowIfNull(nameof(ladStopService));

            _ladStopService = ladStopService;
        }

        [HttpGet("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LadStop>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllAsync()
        {
            var ladStops = await _ladStopService.GetAllAsync();
            return this.List(ladStops);
        }

        [HttpGet("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            var ladStop = await _ladStopService.GetByIdAsync(id);
            return this.Get(ladStop);
        }

        [HttpPost("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateAsync([FromBody] LadStopDto entity)
        {
            await _ladStopService.InsertAsync(entity);
            return Ok();
        }

        [HttpPut("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAsync([FromBody] LadStopDto data)
        {
            await _ladStopService.UpdateAsync(data);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _ladStopService.DeleteAsync(id);
            return Ok();
        }
    }
}