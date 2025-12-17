using Shared.Dto_s.Tour.Destination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Tour
{
    public interface IDestinationService
    {
        Task<List<DestinationDto>> GetAllAsync();
        Task<DestinationDto?> GetByIdAsync(int id);
        Task<DestinationDto> CreateAsync(CreateDestinationDto dto);
        Task<bool> UpdateAsync(int id, UpdateDestinationDto dto);
        Task<bool> DeleteAsync(int id);

        Task<List<DestinationDto>> GetByTourIdAsync(int tourId);
    }
}
