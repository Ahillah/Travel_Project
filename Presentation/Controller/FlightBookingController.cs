using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.Booking_Transaction;
using Shared.Dto_s.Booking_TransactionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightBookingController:ControllerBase
    {
        private readonly IFlightBookingService service;

        public FlightBookingController(IFlightBookingService service)
        {
            this.service = service;
        }
        [HttpGet("booking/{bookingId}")]
        public async Task<ActionResult<FlightBookingDto?>> GetByBookingIdAsync(int bookingId)
        { 
          var FlightBooking= await service.GetByBookingIdAsync(bookingId);
            if (FlightBooking == null)
            {
                return NotFound($"Flight booking with BookingId {bookingId} not found.");
            }
            return Ok(FlightBooking);
        }
        [HttpGet("{flightId}")]
        public async Task<ActionResult<IEnumerable<FlightBookingDto>>> GetByFlightIdAsync(int flightId)
        {
            var FlightBookings= await service.GetByFlightIdAsync(flightId);
            return Ok(FlightBookings);
        }
        [HttpPost]
        public async Task<ActionResult<FlightBookingDto>> CreateFlightBookingAsync(FlightBookingCreateDto dto)
        {
            var createdBooking = await service.CreateFlightBookingAsync(dto);
            return CreatedAtAction(nameof(GetByBookingIdAsync), new { bookingId = createdBooking.BookingId }, createdBooking);
        }
        [HttpPut("{bookingId}")]
        public async Task<ActionResult<FlightBookingDto?>> UpdateFlightBookingAsync(int bookingId, FlightBookingUpdateDto dto)
        {
            var updatedBooking = await service.UpdateFlightBookingAsync(bookingId, dto);
            if (updatedBooking == null)
                return NotFound($"Flight booking with BookingId {bookingId} not found.");

            return Ok(updatedBooking);
        }
        [HttpDelete("{bookingId}")]
        public async Task<ActionResult> DeleteFlightBookingAsync(int bookingId)
        {
            var isDeleted = await service.DeleteFlightBookingAsync(bookingId);
            if (!isDeleted)
                return NotFound($"Flight booking with BookingId {bookingId} not found.");

            return NoContent();
        }
    }
}
