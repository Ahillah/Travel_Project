using DomainLayer.Models.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Tours
{
    public interface ITourRepository
    {
        Task<IEnumerable<Models.Tours.Tours>> GetAllAsync();
        Task<Models.Tours.Tours?> GetByIdAsync(int id);
        Task<IEnumerable<Models.Tours.Tours>> GetFeaturedToursAsync();
        Task<IEnumerable<Models.Tours.Tours>> SearchAsync(string? destination, decimal? minPrice, decimal? maxPrice, DateTime? startDate);
        Task AddAsync(Models.Tours.Tours tour);
        void Update(Models.Tours.Tours tour);
        void Delete(Models.Tours.Tours tour);
        Task SaveChangesAsync();
    }
}
