using Shared.Dto_s.FlightDto.FlightOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.flight
{
    public interface IFlightOfferService
    {
        Task<IEnumerable<FlightOfferDto>> GetAllOffersAsync();

        Task<FlightOfferDto?> GetOfferByIdAsync(int id);

        Task<FlightOfferDto> CreateOfferAsync(FlightOfferCreatedDto dto);

        Task<FlightOfferDto?> UpdateOfferAsync(int id, FlightOfferUpdatedDto dto);

        Task<bool> DeleteOfferAsync(int id);

        Task<IEnumerable<FlightOfferDto>?> GetActiveOffersAsync(DateTime today);

        Task<IEnumerable<FlightOfferDto>?> GetOffersByDestinationAsync(int arrivalAirportId);
    }
}
