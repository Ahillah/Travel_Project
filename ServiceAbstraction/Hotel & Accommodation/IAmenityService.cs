using Shared.Dto_s.Hotel___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction.Hotel___Accommodation
{
    public interface IAmenityService
    {
    

        Task<IEnumerable<AmenityDto>> GetAllAsync();
        Task<AmenityDto> GetByIdAsync(int id);
        Task<AmenityDto> CreateAsync(AmenityDto dto);
        Task<bool> UpdateAsync(int id, AmenityDto dto);
        Task<bool> DeleteAsync(int id);

    }
}
