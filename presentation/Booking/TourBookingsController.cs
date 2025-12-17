using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Booking;
using Shared.Dto_s.Booking.TourBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presentation.Booking
{
    [ApiController]
    [Route("api/tour-bookings")]
    public class TourBookingsController : ControllerBase
    {
        private readonly ITourBookingService _service;

        public TourBookingsController(ITourBookingService service)
        {
            _service = service;
        }

        // 1️ Create
        [HttpPost]
        public async Task<IActionResult> Create(CreateTourBookingDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetByBookingId),
                new { bookingId = result.BookingId }, result);
        }

        // 2️ Get by BookingId
        [HttpGet("booking/{bookingId}")]
        public async Task<IActionResult> GetByBookingId(int bookingId)
        {
            var result = await _service.GetByBookingIdAsync(bookingId);
            return result == null ? NotFound() : Ok(result);
        }

        // 3️ Update
        [HttpPut("{bookingId}")]
        public async Task<IActionResult> Update(int bookingId, UpdateTourBookingDto dto)
        {
            var updated = await _service.UpdateAsync(bookingId, dto);
            return updated ? Ok() : NotFound();
        }

        // 4️ Delete
        [HttpDelete("{bookingId}")]
        public async Task<IActionResult> Delete(int bookingId)
        {
            var deleted = await _service.DeleteAsync(bookingId);
            return deleted ? Ok() : NotFound();
        }

        // 5 Get Booking Tour Details By BookingId
        [HttpGet("api/bookings/{bookingId}/tour")]
        public async Task<IActionResult> GetBookingTourById(int bookingId)
        {
            var result = await _service.GetBookingTourByIdAsync(bookingId);
            return result == null ? NotFound() : Ok(result);
        }
    }
}
