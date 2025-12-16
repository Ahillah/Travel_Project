using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Hotel___Accommodation;
using Shared.Dto_s.Hotel___Accommodation;

namespace presentation.Controllers.Hotel___Accommodation
{


    //[ApiController]
    //[Route("api/room")]
    //public class RoomController : ControllerBase
    //{
    //    private readonly IRoomService _service;
    //    public RoomController(IRoomService service) => _service = service;

    //    [HttpGet("all")]
    //    public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

    //    [HttpGet("hotel/{hotelId}")]
    //    public async Task<IActionResult> GetByHotel(int hotelId) => Ok(await _service.GetByHotelAsync(hotelId));

    //    [HttpGet("{id}")]
    //    public async Task<IActionResult> GetById(int id)
    //    {
    //        var r = await _service.GetByIdAsync(id);
    //        if (r == null) return NotFound();
    //        return Ok(r);
    //    }

    //    [HttpPost("create")]
    //    public async Task<IActionResult> Create(RoomDto dto)
    //    {
    //        var created = await _service.AddAsync(dto);

    //        return Ok(created);
    //    }

    //    [HttpPut("update/{id}")]
    //    public async Task<IActionResult> Update(UpdateRoomDto dto, int id)
    //    {
    //        var ok = await _service.UpdateAsync(dto, id);
    //        if (!ok) return NotFound();
    //        return NoContent();
    //    }

    //    [HttpDelete("delete/{id}")]
    //    public async Task<IActionResult> Delete(int id)
    //    {
    //        var ok = await _service.DeleteAsync(id);
    //        if (!ok) return NotFound();
    //        return NoContent();
    //    }
    //}
    [ApiController]
    [Route("api/room")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service = service;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
            => Ok(await _service.GetAllAsync());

        [HttpGet("hotel/{hotelId}")]
        public async Task<IActionResult> GetByHotel(int hotelId)
            => Ok(await _service.GetByHotelAsync(hotelId));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var r = await _service.GetByIdAsync(id);
            return r == null ? NotFound() : Ok(r);
        }

        //[HttpPost("create")]
        //public async Task<IActionResult> Create([FromBody] RoomDto dto)
        //{
        //    var created = await _service.AddAsync(dto);
        //    return Ok(created);
        //}
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] RoomDto dto)
        {
            var created = await _service.AddAsync(dto);

            if (created == null)
                return BadRequest(new { message = "Room not created" });

            return Ok(new { message = "Room created successfully", data = created });
        }


        //[HttpPut("update/{id}")]
        //public async Task<IActionResult> Update(int id, [FromBody] UpdateRoomDto dto)
        //{
        //    var ok = await _service.UpdateAsync(dto, id);
        //    return ok ? NoContent() : NotFound();
        //}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRoomDto dto)
        {
            var ok = await _service.UpdateAsync(dto, id);

            if (ok)
                return Ok(new { message = "Room updated successfully" });

            return NotFound(new { message = "Room not updated or not found" });
        }


        //[HttpDelete("delete/{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var ok = await _service.DeleteAsync(id);
        //    return ok ? NoContent() : NotFound();
        //}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (ok)
            {
                return Ok(new { message = "Deleted successfully" });
            }
            return NotFound(new { message = "Item not found" });
        }

    }


}
