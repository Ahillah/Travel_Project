//using Microsoft.AspNetCore.Mvc;
//using ServiceAbstraction.Hotel___Accommodation;
//using DomainLayer.DTOs.HotelAccommodation;

//[Route("api/[controller]")]
//[ApiController]
//public class HotelAmenityController : ControllerBase
//{
//    private readonly IHotelAmenityService _service;

//    public HotelAmenityController(IHotelAmenityService service)
//    {
//        _service = service;
//    }

//    // ------------------- Get All -------------------
//    [HttpGet("get-all")]
//    public async Task<IActionResult> GetAll()
//    {
//        var result = await _service.GetAllAsync();
//        return Ok(result);
//    }

//    // ------------------- Get by Composite Key -------------------
//    [HttpGet("get/{hotelId:int}/{amenityId:int}")]
//    public async Task<IActionResult> GetById(int hotelId, int amenityId)
//    {
//        var result = await _service.GetByIdAsync(hotelId, amenityId);

//        if (result == null)
//            return NotFound(new { message = "HotelAmenity not found" });

//        return Ok(result);
//    }

//    // ------------------- Create -------------------
//    [HttpPost("create")]
//    public async Task<IActionResult> Create([FromBody] HotelAmenityCreateDto dto)
//    {
//        if (!ModelState.IsValid)
//            return BadRequest(ModelState);

//        var ok = await _service.CreateAsync(dto);

//        if (!ok)
//            return BadRequest(new { message = "Failed to create hotel amenity" });

//        return Ok(new { message = "Created successfully" });
//    }

//    // ------------------- Update -------------------
//    [HttpPut("update/{hotelId:int}/{amenityId:int}")]
//    public async Task<IActionResult> Update(
//        int hotelId,
//        int amenityId,
//        [FromBody] HotelAmenityDto dto)
//    {
//        if (!ModelState.IsValid)
//            return BadRequest(ModelState);

//        var ok = await _service.UpdateAsync(hotelId, amenityId, dto);

//        if (!ok)
//            return NotFound(new { message = "HotelAmenity not found" });

//        return Ok(new { message = "Updated successfully" });
//    }

//    // ------------------- Delete -------------------
//    [HttpDelete("delete/{hotelId:int}/{amenityId:int}")]
//    public async Task<IActionResult> Delete(int hotelId, int amenityId)
//    {
//        var ok = await _service.DeleteAsync(hotelId, amenityId);

//        if (!ok)
//            return NotFound(new { message = "HotelAmenity not found" });

//        return Ok(new { message = "Deleted successfully" });
//    }
//}
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Hotel___Accommodation;
using Shared.Dto_s.Hotel___Accommodation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers.Hotel___Accommodation
{
    [ApiController]
    [Route("api/hotelAmenity")]
    public class HotelAmenityController : ControllerBase
    {
        private readonly IHotelAmenityService _service;

        public HotelAmenityController(IHotelAmenityService service)
        {
            _service = service;
        }

        // GET: api/hotelAmenity/get-all
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        // GET: api/hotelAmenity/get/{hotelId}/{amenityId}
        [HttpGet("get/{hotelId:int}/{amenityId:int}")]
        public async Task<IActionResult> GetById(int hotelId, int amenityId)
        {
            var data = await _service.GetByIdAsync(hotelId, amenityId);
            if (data == null)
                return NotFound(new { message = "HotelAmenity not found" });

            return Ok(data);
        }

        // GET: api/hotelAmenity/hotel/{hotelId}
        [HttpGet("hotel/{hotelId:int}")]
        public async Task<IActionResult> GetByHotel(int hotelId)
        {
            var data = await _service.GetByHotelAsync(hotelId);
            return Ok(data);
        }

        // POST: api/hotelAmenity/add
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] HotelAmenityDto dto)
        {
            var created = await _service.AddAsync(dto);
            return Created("", created);
        }

        // DELETE: api/hotelAmenity/delete/{hotelId}/{amenityId}
        [HttpDelete("delete/{hotelId:int}/{amenityId:int}")]
        public async Task<IActionResult> Delete(int hotelId, int amenityId)
        {
            var ok = await _service.DeleteAsync(hotelId, amenityId);
            if (!ok)
                return NotFound(new { message = "HotelAmenity not found" });

            return Ok(new {message = "delete done"});
        }
    }
}
