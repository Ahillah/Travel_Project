using DomainLayer.Models.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Tours
{
    public interface ITourInclusionRepository
    {
        Task<IEnumerable<TourInclusion>> GetByTourIdAsync(int tourId);
        Task<TourInclusion> GetByIdAsync(int id);
        Task AddAsync(TourInclusion inclusion);
        Task UpdateAsync(TourInclusion inclusion);
        Task DeleteAsync(TourInclusion inclusion);
        Task SaveChangesAsync();
    }
}
