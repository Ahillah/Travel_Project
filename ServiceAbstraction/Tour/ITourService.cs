using Shared.Dto_s.Tour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Tour
{
    public interface ITourService
    {
        Task<IEnumerable<TourDto>> GetAllAsync();
        Task<TourDto?> GetByIdAsync(int id);
        Task<IEnumerable<TourDto>> GetFeaturedToursAsync();
        Task<IEnumerable<TourDto>> SearchAsync(string? destination, decimal? minPrice, decimal? maxPrice, DateTime? startDate);
        Task<TourDto> CreateAsync(CreateTourDto dto);
        Task<bool> UpdateAsync(int id, UpdateTourDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
