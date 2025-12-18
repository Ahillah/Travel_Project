using DomainLayer.Models.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Tours
{
    public interface ITourDateRepository
    {
        Task<IEnumerable<TourDate>> GetAllAsync();
        Task<TourDate> GetByIdAsync(int id);
        Task<IEnumerable<TourDate>> GetByTourIdAsync(int tourId);
        Task<TourDate> AddAsync(TourDate tourDate);
        Task UpdateAsync(TourDate tourDate);
        Task DeleteAsync(int id);

        Task<IEnumerable<TourDate>> GetUpcomingAsync();
        Task<IEnumerable<TourDate>> FilterAsync(decimal? minPrice, decimal? maxPrice, DateTime? startDate);

        Task<bool> CheckAvailabilityAsync(int id);
    }
}
