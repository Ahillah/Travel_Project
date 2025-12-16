using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.flight;
using Shared.Dto_s.FlightDto.FlightPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightPriceController:ControllerBase
    {
        private readonly IFlightPriceService service;

        public FlightPriceController(IFlightPriceService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightPriceDto>>> GetAllPrices()
        {
            var prices = await service.GetAllPricesAsync();
           
            return Ok(prices);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightPriceDto>> GetPriceById(int id)
        {
            var price = await service.GetPriceByIdAsync(id);
            if (price == null)
                return NotFound($"Flight Price with ID {id} not found.");

            return Ok(price);
        }
        [HttpGet("search")]
        public async Task<ActionResult<FlightPriceDto>> GetPriceByClassAndFlight(
            [FromQuery] int flightId,
            [FromQuery] string className)
        {
            if (string.IsNullOrWhiteSpace(className))
            {
                return BadRequest("Class name must be provided.");
            }

            var price = await service.GetPriceByClassAndFlightAsync(flightId, className);

            if (price == null)
                
                return NotFound($"Price for Flight {flightId} and Class '{className}' not found.");

            return Ok(price);
        }
        [HttpPost]
        public async Task<ActionResult<FlightPriceDto>> CreatePrice(FlightPriceCreatedDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var price = await service.CreatePriceAsync(dto);

     
            return CreatedAtAction(nameof(GetPriceById), new { id = price.Id }, price);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<FlightPriceDto>> UpdatePrice(int id, FlightPriceUpdatedDto updatedDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedPrice = await service.UpdatePriceAsync(id, updatedDto);

            if (updatedPrice == null)
            {
                return NotFound($"Flight Price with ID {id} not found.");
            }

            return Ok(updatedPrice);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePrice(int id)
        {
            var isDeleted = await service.DeletePriceAsync(id);

            if (!isDeleted)
                return NotFound($"Flight Price with ID {id} not found or could not be deleted.");

            return NoContent();
        }
    }
}
