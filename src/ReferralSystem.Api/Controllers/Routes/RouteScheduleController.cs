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
    public class RouteScheduleController : ControllerBase
    {
        private readonly IRouteScheduleService _routeScheduleService;

        public RouteScheduleController(IRouteScheduleService routeScheduleService)
        {
            routeScheduleService.ThrowIfNull(nameof(routeScheduleService));

            _routeScheduleService = routeScheduleService;
        }

        [HttpGet("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<RouteSchedule>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllAsync()
        {
            var routeSchedules = await _routeScheduleService.GetAllAsync();
            return this.List(routeSchedules);
        }

        [HttpGet("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            var routeSchedule = await _routeScheduleService.GetByIdAsync(id);
            return this.Get(routeSchedule);
        }

        [HttpPost("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateAsync([FromBody] RouteScheduleDto entity)
        {
            await _routeScheduleService.InsertAsync(entity);
            return Ok();
        }

        [HttpPut("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAsync([FromBody] RouteScheduleDto data)
        {
            await _routeScheduleService.UpdateAsync(data);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _routeScheduleService.DeleteAsync(id);
            return Ok();
        }
    }
}