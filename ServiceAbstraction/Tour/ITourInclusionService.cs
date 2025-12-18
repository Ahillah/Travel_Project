using Shared.Dto_s.Tour.TourInclusion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Tour
{
    public interface ITourInclusionService
    {
        Task<IEnumerable<TourInclusionDto>> GetByTourIdAsync(int tourId);
        Task<TourInclusionDto> GetByIdAsync(int id);
        Task<TourInclusionDto> CreateAsync(int tourId, CreateTourInclusionDto dto);
        Task<TourInclusionDto> UpdateAsync(int id, UpdateTourInclusionDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
