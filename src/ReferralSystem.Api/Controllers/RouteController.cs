using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Domain.Services.Routes;
using ReferralSystem.Models.Domain.Routes;

namespace ReferralSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouteController : ControllerBase
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public virtual async Task<IEnumerable<Route>> GetAllAsync()
        {
            return await _routeService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public virtual async Task<Route> GetByIdAsync([FromRoute] long id)
        {
            return await _routeService.GetByIdAsync(id);
        }

        [HttpPost]
        public virtual async Task<IActionResult> CreateAsync([FromBody] RouteDto entity)
        {
            await _routeService.InsertAsync(entity);
            return Ok();
        }

        [HttpPut]
        public virtual async Task<IActionResult> UpdateAsync([FromBody] RouteDto data)
        {
            await _routeService.UpdateAsync(data);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _routeService.DeleteAsync(id);
            return Ok();
        }
    }
}