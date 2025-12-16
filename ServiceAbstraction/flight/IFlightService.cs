using Shared.Dto_s.FlightDto.flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.flight
{
    public interface IFlightService
    {
    

        Task<IEnumerable<Flight_Dto>> GetAllFlightsAsync();
        Task<Flight_Dto> CreateFlightAsync(FlightCreatedDto dto);

        Task<Flight_Dto?> UpdateFlightAsync(int id, FlightUpdatedDto dto);

        Task<bool> DeleteFlightAsync(int id);

        Task<FlightDetailsDto?> GetFlightDetailsAsync(int id);
        Task<IEnumerable<Flight_Dto>> SearchFlightsAsync(int departureAirportId, int arrivalAirportId, DateTime date);

        Task<bool> CheckAvailabilityAsync(int flightId, int passengerCount);

        Task<FlightDetailsDto?> GetFlightWithPricesAsync(int id);
    }
}
