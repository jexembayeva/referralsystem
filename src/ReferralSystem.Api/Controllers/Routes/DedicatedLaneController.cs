using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Domain.Services.Routes.DedicatedLanes;
using ReferralSystem.General.Services.Controllers;
using ReferralSystem.Models.Domain.Routes;
using Utils.Helpers;

namespace ReferralSystem.Api.Controllers.Routes
{
    [Route("[controller]")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class DedicatedLaneController : ControllerBase
    {
        private readonly IDedicatedLaneService _dedicatedLaneService;

        public DedicatedLaneController(IDedicatedLaneService dedicatedLaneService)
        {
            dedicatedLaneService.ThrowIfNull(nameof(dedicatedLaneService));

            _dedicatedLaneService = dedicatedLaneService;
        }

        [HttpGet("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DedicatedLane>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllAsync()
        {
            var dedicatedLanes = await _dedicatedLaneService.GetAllAsync();
            return this.List(dedicatedLanes);
        }

        [HttpGet("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            var dedicatedLane = await _dedicatedLaneService.GetByIdAsync(id);
            return this.Get(dedicatedLane);
        }

        [HttpPost("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateAsync([FromBody] DedicatedLaneDto entity)
        {
            await _dedicatedLaneService.InsertAsync(entity);
            return Ok();
        }

        [HttpPut("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAsync([FromBody] DedicatedLaneDto data)
        {
            await _dedicatedLaneService.UpdateAsync(data);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _dedicatedLaneService.DeleteAsync(id);
            return Ok();
        }
    }
}