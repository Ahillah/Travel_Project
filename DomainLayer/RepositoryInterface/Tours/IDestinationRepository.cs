using DomainLayer.Models.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Tours
{
    public interface IDestinationRepository
    {
        Task<List<Destination>> GetAllAsync();
        Task<Destination?> GetByIdAsync(int id);
        Task AddAsync(Destination entity);
        Task UpdateAsync(Destination entity);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();

        // خاص بجلب Destinations حسب التور
        Task<List<Destination>> GetByTourIdAsync(int tourId);
    }
}
