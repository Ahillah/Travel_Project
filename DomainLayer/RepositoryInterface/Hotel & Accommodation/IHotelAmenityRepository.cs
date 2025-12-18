using DomainLayer.Models.Hotels___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Hotel___Accommodation
{
    public interface IHotelAmenityRepository
    {
        Task<HotelAmenity> GetByIdAsync(int hotelId, int amenityId);
        Task<bool> SaveAsync();
        Task<IEnumerable<HotelAmenity>> GetByHotelAsync(int hotelId);
        Task<HotelAmenity> AddAsync(HotelAmenity entity);
        Task<bool> DeleteAsync(int hotelId, int amenityId);
        Task<IEnumerable<HotelAmenity>> GetAllAsync();
    }
}
