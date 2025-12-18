using DomainLayer.Models.Hotels___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Hotel___Accommodation
{
    public interface IAmenityRepository
    {
        Task<IEnumerable<Amenity>> GetAllAsync();
        Task<Amenity> GetByIdAsync(int id);
        Task<Amenity> AddAsync(Amenity amenity);
        Task<bool> UpdateAsync(Amenity amenity);
        Task<bool> DeleteAsync(int id);

    }
}
