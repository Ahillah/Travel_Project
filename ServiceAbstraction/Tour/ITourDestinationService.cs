using DomainLayer.Models.Tours;
using Shared.Dto_s.Tour.TourDestination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Tour
{
    public interface ITourDestinationService
    {
        Task<IEnumerable<TourDestinationDto>> GetAllAsync();
        Task<TourDestination?> GetByIdAsync(int destinationId);
        Task<bool> AddAsync(AddTourDestinationDto dto);
        Task DeleteAsync(int destinationId);
        Task<IEnumerable<Destination>> GetDestinationsByTourAsync(int tourId);
        Task<IEnumerable<Tours>> GetToursByDestinationAsync(int destinationId);
    }
}
