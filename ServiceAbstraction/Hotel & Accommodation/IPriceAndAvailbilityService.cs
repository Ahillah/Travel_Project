using Shared.Dto_s.Hotel___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Hotel___Accommodation
{
    public interface IPriceAndAvailbilityService
    {
        Task<IEnumerable<PriceAndAvailabilityDto>> GetAllAsync();
        Task<PriceAndAvailabilityDto> GetByIdAsync(int roomId, DateTime date);
        Task<bool> DeleteAsync(int roomId, DateTime date);
        Task<IEnumerable<RoomAvailabilityDto>> GetRoomAvailabilityAsync(int propertyId, DateTime start, DateTime end);

        Task<IEnumerable<PriceAndAvailabilityDto>> GetByRoom(int roomId);
        Task<PriceAndAvailabilityDto> CreateAsync(PriceAndAvailabilityDto dto);
        Task<bool> UpdateAsync(int roomId, DateTime date, PriceAndAvailabilityDto dto);
    }
}
