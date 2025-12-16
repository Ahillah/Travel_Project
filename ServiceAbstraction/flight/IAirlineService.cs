using Shared.Dto_s.FlightDto.Airline;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.flight
{
    public interface IAirlineService
    {
        Task<IEnumerable<AirlineDto>> GetAllAirlinesAsync();
        Task<IEnumerable<AirlineDto>> SearchAirlinesAsync(string searchValue);
        Task<AirlineDto?> GetAirlineByIdAsync(int id); 
        Task<AirlineDto> CreateAirlineAsync(AirlineCreateDto dto);
        Task<AirlineDto?> UpdateAirlineAsync(AirlineUpdateDto dto);
        Task<bool> DeleteAirlineAsync(int id);
    }
}
