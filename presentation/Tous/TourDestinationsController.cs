using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Tour;
using Shared.Dto_s.Tour.TourDestination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presentation.Tous
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourDestinationsController(ITourDestinationService service) : ControllerBase
    {
        private readonly ITourDestinationService _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{destinationId}")]
        public async Task<IActionResult> GetById(int destinationId)
        {
            var destination = await _service.GetByIdAsync(destinationId);
            if (destination == null)
                return NotFound();
            return Ok(destination);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTourDestinationDto dto)
        {
            var added = await _service.AddAsync(dto);
            return added ? Ok("Added Successfully") : BadRequest("Relation already exists");
        }

        [HttpDelete("{destinationId}")]
        public async Task<IActionResult> Delete(int destinationId)
        {
            var existing = await _service.GetByIdAsync(destinationId);
            if (existing == null)
                return NotFound();

            await _service.DeleteAsync(destinationId);
            return Ok("Deleted Successfully");
        }

        [HttpGet("tour/{tourId}")]
        public async Task<IActionResult> GetDestinationsByTour(int tourId)
        {
            return Ok(await _service.GetDestinationsByTourAsync(tourId));
        }

        [HttpGet("destination/{destinationId}")]
        public async Task<IActionResult> GetToursByDestination(int destinationId)
        {
            return Ok(await _service.GetToursByDestinationAsync(destinationId));
        }
    }
}
