using Shared.Dto_s.Hotel___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Hotel___Accommodation
{
    public interface IRoomService
    {
        Task<IEnumerable<RoomDto>> GetAllAsync();
        Task<RoomDto> GetByIdAsync(int Id);
        Task <RoomDto> AddAsync(RoomDto room);
        Task <bool> UpdateAsync(UpdateRoomDto room ,int id);
        Task <bool> DeleteAsync(int id);
        Task<bool> SaveChangesAsync();

        Task<IEnumerable<RoomDto>> GetByHotelAsync(int hotelId);



    }
}
