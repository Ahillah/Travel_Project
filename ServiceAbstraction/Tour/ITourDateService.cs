using Shared.Dto_s.Tour.TourDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Tour
{
    public interface ITourDateService
    {
        Task<IEnumerable<TourDateDto>> GetAllAsync();
        Task<TourDateDto> GetByIdAsync(int id);
        Task<IEnumerable<TourDateDto>> GetByTourIdAsync(int tourId);
        Task<TourDateDto> CreateAsync(CreateTourDateDto dto);
        Task UpdateAsync(int id, UpdateTourDateDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<TourDateDto>> GetUpcomingAsync();
        Task<IEnumerable<TourDateDto>> FilterAsync(decimal? minPrice, decimal? maxPrice, DateTime? startDate);
        Task<bool> CheckAvailabilityAsync(int id);
    }
}
