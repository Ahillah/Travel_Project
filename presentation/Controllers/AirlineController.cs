using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.flight;
using Shared.Dto_s.FlightDto.Airline;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirlineController : ControllerBase
    {
        private readonly IAirlineService airlineService;

        public AirlineController(IAirlineService airlineService)
        {
            this.airlineService = airlineService;
        }
        [HttpGet("Airlines")]
        public async Task<ActionResult<IEnumerable<AirlineDto>>> GetAllAirlines()
        {

            var Airlines = await airlineService.GetAllAirlinesAsync();

            return Ok(Airlines);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AirlineDto>> GetAirlineById(int id)
        {
            var Airline = await airlineService.GetAirlineByIdAsync(id);
            if (Airline == null)
                return NotFound();
            return Ok(Airline);
        }
        [HttpPut]
        public async Task<ActionResult<AirlineDto>> UpdateAirlineAsync(AirlineUpdateDto airline)
        {

            var Airline = await airlineService.UpdateAirlineAsync(airline);
            if (Airline == null)
                return NotFound();
            return Ok(Airline);
        }
        [HttpPost]
        public async Task<ActionResult<AirlineDto>> CreateAirlineAsync(AirlineCreateDto airlineCreateDto)
        {
            var Airline = await airlineService.CreateAirlineAsync(airlineCreateDto);
            return CreatedAtAction(nameof(GetAirlineById), new { id = Airline.Id }, Airline);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAirlineAsync(int id)
        {

            var isDelted = await airlineService.DeleteAirlineAsync(id);
            if (!isDelted) return NotFound();
            return NoContent();
        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<AirlineDto>>> GetAirlinesWithFilterAsync([FromQuery]string searchValue)
        {
            var Airlines = await airlineService.SearchAirlinesAsync(searchValue);
            return Ok(Airlines);
        }
    }
}