using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.flight;
using Shared.Dto_s.FlightDto.Airline;
using Shared.Dto_s.FlightDto.Airport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirportController:ControllerBase
    {
        private readonly IAirportService service;
        public AirportController(IAirportService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AirportDto>>> GetAllAirports()
        {

            var Airports= await service.GetAllAirportsAsync();

            return Ok(Airports);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AirportDto>> GetAirportById(int id)
        {
            var Airport = await service.GetAirportByIdAsync(id);
            if (Airport == null)
                return NotFound($"Airport with ID {id} not found.");
            return Ok(Airport);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<AirportDto>> UpdateAirportAsync(int id,AirportUpdatedDto updatedDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedAirport = await service.UpdateAirportAsync(id, updatedDto);
            if (updatedAirport == null)
            { 
                return NotFound($"Airport with ID {id} not found.");
            }

            
            return Ok(updatedAirport);

        }
        [HttpPost]
        public async Task<ActionResult<AirportDto>> CreateAirportAsync(AirportCreatedDto dto)
        {
            var Airport = await service.CreateAirportAsync(dto);
            return CreatedAtAction(nameof(GetAirportById), new { id = Airport.Id }, Airport);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAirportAsync(int id)
        {

            var isDelted = await service.DeleteAirportAsync(id);
            if (!isDelted) return NotFound("Airport with ID {id} not found.");
            return NoContent();
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<AirportDto>>> GetAirportsWithFilterAsync([FromQuery] string searchValue)
        {
            var Airport = await  service.SearchAirportAsync(searchValue);
            if (Airport == null)
                return NotFound();
            return Ok(Airport);
        }
        [HttpGet("flights/{id}")]  
        public async Task<ActionResult<AirportDetailsDto>> GetAirportWithFlightsAsync(int id)
        {
            var Airports = await service.GetAirportWithFlightsAsync(id);
            if(Airports == null)
                return NotFound();
            return Ok(Airports);
        }
        [HttpGet("offers/{id}")]
        public async Task<ActionResult<AirportDetailsDto?>> GetAirportWithOffersAsync(int id)
        {
            var Airport = await service.GetAirportWithOffersAsync(id);
            if(Airport  == null)
                return NotFound();
            return Ok(Airport);
        }
    }

}
