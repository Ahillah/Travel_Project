using DomainLayer.Models.Hotels___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Hotel___Accommodation
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> GetAllAsync();
        Task<Hotel> GetByIdAsync(int id);
        Task<Hotel> AddAsync(Hotel entity);
        Task<bool> SaveAsync();
       
        Task<bool> UpdateAsync(Hotel hotel);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Hotel>> GetHotelsByCityAsync(string city);
        Task<IEnumerable<Hotel>> SearchHotelsAsync(string location, DateTime checkIn, DateTime checkOut, int guests);
        Task<Hotel> GetPropertyDetailsAsync(int propertyId);
        Task<IEnumerable<Hotel>> GetSimilarPropertiesAsync(int propertyId);

    }
}
