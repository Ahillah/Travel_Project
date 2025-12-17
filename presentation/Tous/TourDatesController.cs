using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Tour;
using Shared.Dto_s.Tour.TourDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presentation.Tous
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourDatesController : ControllerBase
    {
        private readonly ITourDateService _service;

        public TourDatesController(ITourDateService service)
        {
            _service = service;
        }

        // 1) GET All
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // 2) GET by Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        // 3) GET Dates by TourId
        [HttpGet("tour/{tourId}")]
        public async Task<IActionResult> GetByTourId(int tourId)
        {
            var result = await _service.GetByTourIdAsync(tourId);
            return Ok(result);
        }

        // 4) POST Create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTourDateDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // 5) PUT Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTourDateDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        // 6) DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Ok("Deleted");
        }

        // 7) Upcoming Tours
        [HttpGet("upcoming")]
        public async Task<IActionResult> GetUpcoming()
        {
            var result = await _service.GetUpcomingAsync();
            return Ok(result);
        }

        // 8) Filter
        [HttpGet("filter")]
        public async Task<IActionResult> Filter([FromQuery] decimal? minPrice,
                                                [FromQuery] decimal? maxPrice,
                                                [FromQuery] DateTime? startDate)
        {
            var result = await _service.FilterAsync(minPrice, maxPrice, startDate);
            return Ok(result);
        }

        // 9) Availability
        [HttpGet("{id}/availability")]
        public async Task<IActionResult> CheckAvailability(int id)
        {
            var available = await _service.CheckAvailabilityAsync(id);
            return Ok(new { available = available });
        }
    }
}
