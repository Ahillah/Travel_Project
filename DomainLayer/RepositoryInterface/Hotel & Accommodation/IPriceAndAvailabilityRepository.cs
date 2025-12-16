using DomainLayer.Models.Hotels___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Hotel___Accommodation
{
    public interface IPriceAndAvailabilityRepository
    {
        Task<IEnumerable<PricesAndAvailability>> GetAllAsync();
        Task<PricesAndAvailability> GetByIdAsync(int roomId, DateTime date);
        Task<PricesAndAvailability> AddAsync(PricesAndAvailability entity);
        Task<bool> Update(PricesAndAvailability entity);
        Task<bool> DeleteAsync(int roomId, DateTime date);
        Task<bool> SaveAsync();
        Task<IEnumerable<PricesAndAvailability>> GetRoomAvailabilityAsync(int propertyId, DateTime start, DateTime end);
        Task<IEnumerable<PricesAndAvailability>> GetByRoom(int roomId);
    }

}
