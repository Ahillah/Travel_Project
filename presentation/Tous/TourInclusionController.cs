using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Tour;
using Shared.Dto_s.Tour.TourInclusion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presentation.Tous
{
    [ApiController]
    [Route("api")]
    public class TourInclusionController : ControllerBase
    {
        private readonly ITourInclusionService _service;

        public TourInclusionController(ITourInclusionService service)
        {
            _service = service;
        }

        // 1. Get All Inclusions for a Tour
        [HttpGet("tours/{tourId}/inclusions")]
        public async Task<IActionResult> GetByTourId(int tourId)
        {
            return Ok(await _service.GetByTourIdAsync(tourId));
        }

        // 2. Get Inclusion by Id
        [HttpGet("tour-inclusions/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var inc = await _service.GetByIdAsync(id);
            if (inc == null) return NotFound();
            return Ok(inc);
        }

        // 3. Create Inclusion
        [HttpPost("tours/{tourId}/inclusions")]
        public async Task<IActionResult> Create(int tourId, CreateTourInclusionDto dto)
        {
            var result = await _service.CreateAsync(tourId, dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result
            );
        }

        // 4. Update
        [HttpPut("tour-inclusions/{id}")]
        public async Task<IActionResult> Update(int id, UpdateTourInclusionDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            if (result == null) return NotFound();
            return Ok(result);
        }

        // 5. Delete
        [HttpDelete("tour-inclusions/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
