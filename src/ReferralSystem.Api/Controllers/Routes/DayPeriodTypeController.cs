using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReferralSystem.Domain.Dtos.Routes;
using ReferralSystem.Domain.Services.Routes.DayPeriodTypes;
using ReferralSystem.General.Services.Controllers;
using ReferralSystem.Models.Domain.Routes;
using Utils.Helpers;

namespace ReferralSystem.Api.Controllers.Routes
{
    [Route("[controller]")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class DayPeriodTypeController : ControllerBase
    {
        private readonly IDayPeriodTypeService _dayPeriodTypeService;

        public DayPeriodTypeController(IDayPeriodTypeService dayPeriodTypeService)
        {
            dayPeriodTypeService.ThrowIfNull(nameof(dayPeriodTypeService));

            _dayPeriodTypeService = dayPeriodTypeService;
        }

        [HttpGet("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DayPeriodType>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllAsync()
        {
            var dayPeriodTypes = await _dayPeriodTypeService.GetAllAsync();
            return this.List(dayPeriodTypes);
        }

        [HttpGet("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        {
            var dayPeriodType = await _dayPeriodTypeService.GetByIdAsync(id);
            return this.Get(dayPeriodType);
        }

        [HttpPost("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> CreateAsync([FromBody] DayPeriodTypeDto entity)
        {
            await _dayPeriodTypeService.InsertAsync(entity);
            return Ok();
        }

        [HttpPut("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateAsync([FromBody] DayPeriodTypeDto data)
        {
            await _dayPeriodTypeService.UpdateAsync(data);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _dayPeriodTypeService.DeleteAsync(id);
            return Ok();
        }
    }
}