using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Tour;
using Shared.Dto_s.Tour.Destination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presentation.Tous
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController(IDestinationService service) : ControllerBase
    {
        private readonly IDestinationService _service = service;
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDestinationDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDestinationDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            return updated ? Ok("Updated Successfully") : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? Ok("Deleted Successfully") : NotFound();
        }

        // خاص بالتور
        [HttpGet("/api/tours/{tourId}/destinations")]
        public async Task<IActionResult> GetByTourId(int tourId)
        {
            return Ok(await _service.GetByTourIdAsync(tourId));
        }
    }
}
