using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Domain.Services.Routes.RoutePlans;
using ReferralSystem.General.Services.Controllers;
using ReferralSystem.Models.Domain.Routes;
using Utils.Helpers;

namespace ReferralSystem.Api.Controllers.Routes
{
    [Route("[controller]")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class RoutePlanController : ControllerBase
    {
        private readonly IRoutePlanService _routePlanService;

        public RoutePlanController(IRoutePlanService routePlanService)
        {
            routePlanService.ThrowIfNull(nameof(routePlanService));

            _routePlanService = routePlanService;
        }

        [HttpGet("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RoutePlan>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllAsync()
        {
            var routePlans = await _routePlanService.GetAllAsync();
            return this.List(routePlans);
        }

        [HttpGet("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            var routePlan = await _routePlanService.GetByIdAsync(id);
            return this.Get(routePlan);
        }

        [HttpPost("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateAsync([FromBody] RoutePlanDto entity)
        {
            await _routePlanService.InsertAsync(entity);
            return Ok();
        }

        [HttpPut("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAsync([FromBody] RoutePlanDto data)
        {
            await _routePlanService.UpdateAsync(data);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _routePlanService.DeleteAsync(id);
            return Ok();
        }
    }
}