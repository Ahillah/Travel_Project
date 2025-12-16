using Shared.Dto_s.FlightDto.Airport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.flight
{
    public interface IAirportService
    {
        Task<AirportDto?> GetAirportByIdAsync(int id);
        Task<IEnumerable<AirportDto>?> GetAllAirportsAsync();
        Task<AirportDto> CreateAirportAsync(AirportCreatedDto dto);
        Task<AirportDto?> UpdateAirportAsync(int id,AirportUpdatedDto dto);
        Task<bool> DeleteAirportAsync(int id);

        Task<IEnumerable<AirportDto>> SearchAirportAsync(string searchValue);
        Task<AirportDetailsDto?> GetAirportWithOffersAsync(int id);
        Task<AirportDetailsDto?> GetAirportWithFlightsAsync(int id);


    }
}
