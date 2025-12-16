using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Booking_Transaction;
using Shared.Dto_s.Booking_Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presentation.Controllers.Booking_Transaction
{
    public class HotelBookingControlller : ControllerBase
    {
        [ApiController]
        [Route("api/hotelBookings")]
        public class HotelBookingController : ControllerBase
        {
            private readonly IHotelBookingService _service;

            public HotelBookingController(IHotelBookingService service)
            {
                _service = service;
            }

            [HttpGet("getall")]
            public async Task<IActionResult> GetAll()
            {
                var bookings = await _service.GetBookingAllAsync();
                return Ok(bookings);
            }

            [HttpGet("get/{bookingId:int}")]
            public async Task<IActionResult> GetById(int bookingId)
            {
                var booking = await _service.GetBookingByIdAsync(bookingId);
                if (booking == null) return NotFound();
                return Ok(booking);
            }

            [HttpGet("room/{roomId:int}")]
            public async Task<IActionResult> GetBookingsByRoom(int roomId)
            {
                var bookings = await _service.GetBookingsByRoomAsync(roomId);
                return Ok(bookings);
            }

            [HttpPost("make")]
            public async Task<IActionResult> Add([FromBody] HotelBookingDto dto)
            {
                var created = await _service.AddBookingAsync(dto);
                return Created("", created);
            }

            [HttpPut("update/{bookingId:int}")]
            public async Task<IActionResult> Update(int bookingId, [FromBody] HotelBookingDto dto)
            {
                var updated = await _service.UpdateBookingAsync(bookingId, dto);
                if (!updated) return NotFound();
                return Ok(new { message = "Booking updated successfully" });
            }

            [HttpDelete("delete/{bookingId:int}")]
            public async Task<IActionResult> Delete(int bookingId)
            {
                var deleted = await _service.DeleteBookingAsync(bookingId);
                if (!deleted) return NotFound();
                return NoContent();
            }
        }
    }
}
