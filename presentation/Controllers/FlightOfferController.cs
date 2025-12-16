using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction.flight;
using Shared.Dto_s.FlightDto.FlightOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controller
{

    [ApiController]
    [Route("api/[controller]")]
    public class FlightOfferController:ControllerBase
    {
        private readonly IFlightOfferService service;

        public FlightOfferController(IFlightOfferService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FlightOfferDto>> >GetAllOffers()
        {
            var FlightOffers= await service.GetAllOffersAsync();
            return Ok(FlightOffers);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightOfferDto>> GetOfferById(int id)
        {
            var FlightOffer= await service.GetOfferByIdAsync(id);
            if (FlightOffer == null)
                return NotFound($"Flight Offer with ID {id} not found.");

            return Ok(FlightOffer);
        }
        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<FlightOfferDto>>> GetActiveOffers()
        {
            var ActiveOffers = await service.GetActiveOffersAsync(DateTime.UtcNow);
            return Ok(ActiveOffers);

        }
        [HttpPost]
        public async Task<ActionResult<FlightOfferDto>> CreateOffer(FlightOfferCreatedDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var offer = await service.CreateOfferAsync(dto);

           
            return CreatedAtAction(nameof(GetOfferById), new { id = offer.Id }, offer);
        }
      
        [HttpPut("{id}")]
        public async Task<ActionResult<FlightOfferDto>> UpdateOffer(int id, FlightOfferUpdatedDto updatedDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedOffer = await service.UpdateOfferAsync(id, updatedDto);

            if (updatedOffer == null)
            {
                return NotFound($"Flight Offer with ID {id} not found.");
            }

            return Ok(updatedOffer);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOffer(int id)
        {
            var isDeleted = await service.DeleteOfferAsync(id);

            if (!isDeleted)
                return NotFound($"Flight Offer with ID {id} not found.");

       
            return NoContent();
        }
        [HttpGet("destination/{arrivalAirportId}")]
        public async Task<ActionResult<IEnumerable<FlightOfferDto>>> GetOffersByDestination(int arrivalAirportId)
        {
            var offers = await service.GetOffersByDestinationAsync(arrivalAirportId);
            return Ok(offers);
        }
    }
}
