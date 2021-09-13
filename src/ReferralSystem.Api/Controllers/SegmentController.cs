﻿using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReferralSystem.Domain.Dtos.Segments;
using ReferralSystem.Domain.Services.Segments;
using ReferralSystem.General.Services.Controllers;
using ReferralSystem.Models.Domain.Segments;
using Utils.Helpers;

namespace ReferralSystem.Api.Controllers
{
    [Route("[controller]")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class SegmentController : ControllerBase
    {
        private readonly ISegmentService _segmentService;

        public SegmentController(ISegmentService segmentService)
        {
            segmentService.ThrowIfNull(nameof(segmentService));

            _segmentService = segmentService;
        }

        [HttpGet("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Segment>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
        {
            var routes = await _segmentService.GetAllAsync();
            return this.List(routes);
        }

        [HttpGet("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<Segment> GetByIdAsync([FromRoute] long id)
        {
            return await _segmentService.GetByIdAsync(id);
        }

        [HttpPost("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<IActionResult> CreateAsync([FromBody] SegmentDto entity, CancellationToken cancellationToken)
        {
            await _segmentService.InsertAsync(entity, cancellationToken);
            return Ok();
        }

        [HttpPut("[action]")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public virtual async Task<IActionResult> UpdateAsync([FromBody] SegmentDto data, CancellationToken cancellationToken)
        {
            await _segmentService.UpdateAsync(data, cancellationToken);
            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _segmentService.DeleteAsync(id);
            return Ok();
        }
    }
}