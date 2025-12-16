using ServiceAbstraction.Hotel___Accommodation;
using Shared.Dto_s.Hotel___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace presentation.Controllers.Hotel___Accommodation
{
    [Route("api/amenity")]
    [ApiController]
    public class AmenityController : ControllerBase
    {
        private readonly IAmenityService _service;

        public AmenityController(IAmenityService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();

            return Ok(item);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAmenity(AmenityDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return Ok(created);
        }

        //[HttpPut("update/{id}")]
        //public async Task<IActionResult> UpdateAmenity(int id, AmenityDto dto)
        //{
        //    var result = await _service.UpdateAsync(id, dto);

        //    if (!result) return NotFound();

        //    return Ok("Updated Successfully");
        //}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAmenity(int id, [FromBody] AmenityDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);

            if (!result)
                return NotFound("Amenity not found");

            return Ok("Updated Successfully");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);

            if (!result) return NotFound();

            return Ok("Deleted Successfully");
        }
    }
}
