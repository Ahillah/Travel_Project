using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Tour;
using Shared.Dto_s.Tour.TourItinerary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presentation.Tous
{
    [ApiController]
    [Route("api/itineraries")]
    public class TourItinerariesController : ControllerBase
    {
        private readonly ITourItineraryService _service;

        public TourItinerariesController(ITourItineraryService service)
        {
            _service = service;
        }

        // Get all itineraries for a tour
        [HttpGet("tour/{tourId}")]
        public async Task<IActionResult> GetAll(int tourId)
        {
            var data = await _service.GetByTourIdAsync(tourId);
            return Ok(data);
        }

        // Get itinerary by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var itinerary = await _service.GetByIdAsync(id);
            if (itinerary == null)
                return NotFound();

            return Ok(itinerary);
        }

        // Create itinerary for a tour
        [HttpPost("tour/{tourId}")]
        public async Task<IActionResult> Create(int tourId, CreateTourItineraryDto dto)
        {
            var result = await _service.CreateAsync(tourId, dto);
            return Ok(result);
        }

        // Update itinerary by ID
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTourItineraryDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (!updated) return NotFound();

            return NoContent();
        }

        // Delete itinerary by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null)
                return NotFound();

            await _service.DeleteAsync(id);
            return Ok("Deleted Successfully");
        }
    }
}
