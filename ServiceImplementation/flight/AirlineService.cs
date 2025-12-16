using AutoMapper;
using DomainLayer.Models.Flights;
using DomainLayer.RepositoryInterface.Flights;
using ServiceAbstraction.flight;

using Shared.Dto_s.FlightDto.Airline;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.Flight
{
    public class AirlineService : IAirlineService
    {
        private readonly IAirlineRepository repo;
        private readonly IMapper mapper;

        public AirlineService(IAirlineRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<AirlineDto>> GetAllAirlinesAsync()
        {
            var airline=await  repo.GetAllAsync();
            
            return mapper.Map<IEnumerable<Airline>, IEnumerable<AirlineDto>>(airline);
        }
        public async Task<AirlineDto> CreateAirlineAsync(AirlineCreateDto dto)
        {
            var airline= mapper.Map<Airline>(dto);
            await repo.Add(airline);
            await repo.SaveChangesAsync();
            return mapper.Map<AirlineDto>(airline);

        }
        public async Task<bool> DeleteAirlineAsync(int id)
        {
           var airline=  await repo.GetByIdAsync(id);
            if(airline == null) return false;
             repo.Delete(airline);
            await repo.SaveChangesAsync();
            return true;
            
        }

        public async Task<AirlineDto?> GetAirlineByIdAsync(int id)
        {
            var airline = await repo.GetByIdAsync(id);
            return mapper.Map<AirlineDto>(airline);
        }


        public async Task<IEnumerable<AirlineDto>> SearchAirlinesAsync(string searchValue)
        {
           
            var airline = await repo.SearchAirlinesAsync(searchValue);
            return mapper.Map<IEnumerable<AirlineDto>>(airline);
        }

        public async Task<AirlineDto?> UpdateAirlineAsync(AirlineUpdateDto dto)
        {
            var airline = await repo.GetByIdAsync(dto.Id);
            if (airline == null) return null;
            mapper.Map(dto, airline);
            repo.Update(airline);
            await repo.SaveChangesAsync();
            return mapper.Map<AirlineDto>(airline);
        }

        
      
    }
}
