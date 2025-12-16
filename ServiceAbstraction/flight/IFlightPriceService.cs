using Shared.Dto_s.FlightDto.FlightPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.flight
{
    public interface IFlightPriceService
    {
        Task<FlightPriceDto?> GetPriceByIdAsync(int id);

        Task<IEnumerable<FlightPriceDto>> GetAllPricesAsync();

        Task<FlightPriceDto?> GetPriceByClassAndFlightAsync(int flightId, string className);

        Task<FlightPriceDto> CreatePriceAsync(FlightPriceCreatedDto dto);

        Task<FlightPriceDto?> UpdatePriceAsync(int id, FlightPriceUpdatedDto dto);

        Task<bool> DeletePriceAsync(int id);
    }
}
