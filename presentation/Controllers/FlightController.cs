using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.flight;
using Shared.Dto_s.FlightDto.flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class FlightController :ControllerBase
    {
        private readonly IFlightService service;

        public FlightController(IFlightService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight_Dto>>> GetAllFlights()
        {
            var Flights = await service.GetAllFlightsAsync();
       return Ok(Flights);
        }
        [HttpGet("availability/{flightId}")]
        public async Task<IActionResult>CheckAvailability(int flightId, [FromQuery]int passengerCount)
            {
            if(passengerCount<=0)
                return BadRequest("Passenger count must be greater than zero.");
            var isAvailable = await service.CheckAvailabilityAsync(flightId, passengerCount);
            if (isAvailable)
            {
                return Ok(new { FlightId = flightId, Available = true, Message = "Seats are available." });
            }
            return StatusCode(409, new { FlightId = flightId, Available = false, Message = "Requested number of seats is not available." });


        }
        [HttpPost]
        public async Task<ActionResult<Flight_Dto>> CreateFlight(FlightCreatedDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flight = await service.CreateFlightAsync(dto);

            return CreatedAtAction(nameof(GetFlightDetails), new { id = flight.Id }, flight);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteFlight(int id)
        {
            var isDeleted = await service.DeleteFlightAsync(id);

            if (!isDeleted)
                return NotFound($"Flight with ID {id} not found.");

           
            return NoContent();
        }
        [HttpGet("details/{id}")]
        public async Task<ActionResult<FlightDetailsDto>> GetFlightDetails(int id)
        {
            var flight = await service.GetFlightDetailsAsync(id);
            if (flight == null)
                return NotFound($"Flight with ID {id} not found.");

            return Ok(flight);
        }
        [HttpGet("prices/{id}")]
        public async Task<ActionResult<FlightDetailsDto>> GetFlightWithPrices(int id)
        {
            var flight = await service.GetFlightWithPricesAsync(id);
            if (flight == null)
                return NotFound($"Flight with ID {id} not found.");

            return Ok(flight);
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Flight_Dto>>> SearchFlights(
            [FromQuery] int departureAirportId,
            [FromQuery] int arrivalAirportId,
            [FromQuery] DateTime date)
        {
            var flights = await service.SearchFlightsAsync(departureAirportId, arrivalAirportId, date);
            return Ok(flights);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Flight_Dto>> UpdateFlight(int id, FlightUpdatedDto updatedDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedFlight = await service.UpdateFlightAsync(id, updatedDto);

            if (updatedFlight == null)
            {
                return NotFound($"Flight with ID {id} not found.");
            }

            return Ok(updatedFlight);
        }
    }
}
