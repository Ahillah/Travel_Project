//using Shared.Dto_s.Hotel___Accommodation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ServiceAbstraction.Hotel___Accommodation
//{
//    public interface IHotelAmenityService
//    {
//            //Task<IEnumerable<HotelAmenityDto>> GetAllAsync();
//            Task<HotelAmenityDto> AddAsync(HotelAmenityDto dto);
//            Task<bool> DeleteAsync(int hotelId, int amenityId);
//            Task<IEnumerable<HotelAmenityDto>> GetByHotelAsync(int hotelId);

//    }
//    }
using Shared.Dto_s.Hotel___Accommodation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ServiceAbstraction.Hotel___Accommodation
{
    public interface IHotelAmenityService
    {
        /// <summary>
        /// Get all hotel-amenity relations.
        /// </summary>
        Task<IEnumerable<HotelAmenityDto>> GetAllAsync();

        /// <summary>
        /// Get a hotel-amenity by hotelId and amenityId.
        /// </summary>
        Task<HotelAmenityDto> GetByIdAsync(int hotelId, int amenityId);

        /// <summary>
        /// Get all amenities for a specific hotel.
        /// </summary>
        Task<IEnumerable<HotelAmenityDto>> GetByHotelAsync(int hotelId);

        /// <summary>
        /// Add a new hotel-amenity relation.
        /// </summary>
        Task<HotelAmenityDto> AddAsync(HotelAmenityDto dto);

        /// <summary>
        /// Delete a hotel-amenity relation.
        /// </summary>
        Task<bool> DeleteAsync(int hotelId, int amenityId);
    }
}


