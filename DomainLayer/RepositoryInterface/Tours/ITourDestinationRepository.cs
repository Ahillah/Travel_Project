using DomainLayer.Models.Tours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Tours
{
    public interface ITourDestinationRepository
    {
        Task<IEnumerable<TourDestination>> GetAllAsync();
        Task<TourDestination?> GetByIdAsync(int destinationId);
        Task AddAsync(TourDestination entity);
        Task DeleteAsync(int destinationId);
        Task<IEnumerable<Destination>> GetDestinationsByTourAsync(int tourId);
        Task<IEnumerable<Models.Tours.Tours>> GetToursByDestinationAsync(int destinationId);
        Task SaveChangesAsync();
    }
}
