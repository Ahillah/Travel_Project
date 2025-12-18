using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presentation.Controllers.Hotel___Accommodation
{
    using Microsoft.AspNetCore.Mvc;
    using ServiceAbstraction.Hotel___Accommodation;
    //using ServiceImplementation.Hotel___Accommodation;
    using Shared.Dto_s.Hotel___Accommodation;

    [ApiController]
    [Route("api/hotel")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _service;
        public HotelController(IHotelService service) => _service = service;

        [HttpGet("all")]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var h = await _service.GetByIdAsync(id);
            if (h == null) return NotFound();
            return Ok(h);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] HotelDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        //[HttpPut("update/{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody] HotelDto dto)
        //{
        //    var ok = await _service.UpdateAsync(id, dto);
        //    if (!ok) return NotFound();
        //    return NoContent();
        //}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HotelDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ok = await _service.UpdateAsync(id, dto);

            if (!ok)
                return NotFound(new { message = "Hotel not found" });

            return Ok(new { message = "Hotel updated successfully" });
        }



        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound(new {message = "hotel not deleted"});
            return Ok(new { message = "Hotel deleted successfully" });
        }

        [HttpGet("city/{city}")]
        public async Task<IActionResult> GetHotelsByCity(string city)
        {
            var hotels = await _service.GetHotelsByCityAsync(city);
            return Ok(hotels);
        }
        // GET: api/hotel/search?location=&checkIn=&checkOut=&guests=
        [HttpGet("search")]
        public async Task<IActionResult> SearchProperties(
            [FromQuery] string location,
            [FromQuery] DateTime checkIn,
            [FromQuery] DateTime checkOut,
            [FromQuery] int guests)
        {
            var hotels = await _service.SearchPropertiesAsync(location, checkIn, checkOut, guests);
            return Ok(hotels);
        }
        [HttpGet("details/{propertyId:int}")]
        public async Task<IActionResult> GetPropertyDetails(int propertyId)
        {
            var hotelDetails = await _service.GetPropertyDetailsAsync(propertyId);
            if (hotelDetails == null)
                return NotFound(new { message = "Hotel not found" });

            return Ok(hotelDetails);
        }

        // GET: api/hotels/similar/{propertyId}
        [HttpGet("similar/{propertyId:int}")]
        public async Task<IActionResult> GetSimilarProperties(int propertyId)
        {
            var hotels = await _service.GetSimilarPropertiesAsync(propertyId);
            return Ok(hotels);
        }
    }
}
