using DomainLayer.Models.Tours;
using Shared.Dto_s.Tour.TourItinerary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Tour
{
    public interface ITourItineraryService
    {
        Task<List<TourItineraryDto>> GetByTourIdAsync(int tourId);
        Task<TourItinerary?> GetByIdAsync(int id);
        Task<TourItineraryDto> CreateAsync(int tourId, CreateTourItineraryDto dto);
        Task<bool> UpdateAsync( int id, UpdateTourItineraryDto dto);
        Task DeleteAsync(int id);
    }
}
