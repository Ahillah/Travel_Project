using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Tour;
using Shared.Dto_s.Tour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace presentation.Tous
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToursController : ControllerBase
    {
        private readonly ITourService _service;

        public ToursController(ITourService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tour = await _service.GetByIdAsync(id);
            if (tour == null) return NotFound();
            return Ok(tour);
        }

        [HttpGet("featured")]
        public async Task<IActionResult> Featured()
            => Ok(await _service.GetFeaturedToursAsync());

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? destination, [FromQuery] decimal? minPrice,
            [FromQuery] decimal? maxPrice, [FromQuery] DateTime? startDate)
        {
            return Ok(await _service.SearchAsync(destination, minPrice, maxPrice, startDate));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTourDto dto)
            => Ok(await _service.CreateAsync(dto));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTourDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            return result ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? Ok() : NotFound();
        }
    }
}
