using DomainLayer.Models.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Tours
{
    public interface ITourItineraryRepository
    {
        Task<List<TourItinerary>> GetByTourIdAsync(int tourId);
        Task<TourItinerary?> GetByIdAsync(int id);
        Task AddAsync(TourItinerary entity);
        Task UpdateAsync(TourItinerary entity);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
