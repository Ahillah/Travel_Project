using AutoMapper;
using DomainLayer.Models.Flights;
using DomainLayer.RepositoryInterface.Flights;
using ServiceAbstraction.flight;
using Shared.Dto_s.FlightDto.Airport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.flight
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository repo;
        private readonly IMapper mapper;

        public AirportService(IAirportRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<AirportDto> CreateAirportAsync(AirportCreatedDto dto)
        {
            var Airport= mapper.Map<Airport>(dto);
            await repo.Add(Airport);
            await repo.SaveChangesAsync();
            return mapper.Map<AirportDto>(Airport);

        }

        public async Task<bool> DeleteAirportAsync(int id)
        {
           var Airport =await repo.GetByIdAsync(id);
            if (Airport == null) return false;
            repo.Delete(Airport);
            await repo.SaveChangesAsync();
            return true;
        }

        public async Task<AirportDto?> GetAirportByIdAsync(int id)
        {
           var Airport= await repo.GetByIdAsync(id);
            if (Airport == null)
                return null;
            return mapper.Map<AirportDto>(Airport);
        }

        public async Task<AirportDetailsDto?> GetAirportWithFlightsAsync(int id)
        {
           var Airport=await  repo.GetAirportWithFlightsAsync(id);
            if(Airport == null) 
                return null;
            return mapper.Map<AirportDetailsDto>(Airport);
        }

        public async Task<AirportDetailsDto?> GetAirportWithOffersAsync(int id)
        {
            var Airport = await repo.GetAirportWithOffersAsync(id);
            if (Airport == null)
                return null;
            return mapper.Map<AirportDetailsDto>(Airport);
        }

        public async Task<IEnumerable<AirportDto>?> GetAllAirportsAsync()
        {
            var Airports= await repo.GetAllAsync();
            return mapper.Map<IEnumerable<AirportDto>>(Airports);
        }

        public async Task<IEnumerable<AirportDto>> SearchAirportAsync(string searchValue)
        {
           var Airports = await repo.SearchAirportsAsync(searchValue);
            if (Airports == null)
                return Enumerable.Empty<AirportDto>();
            return mapper.Map<IEnumerable<AirportDto>>(Airports);
                
                


        }

        public async Task<AirportDto?> UpdateAirportAsync(int id,AirportUpdatedDto dto)
        {
          
            var existingAirport = await repo.GetByIdAsync(id);
            if (existingAirport == null)
                return null; 

            
            mapper.Map(dto, existingAirport);

            repo.Update(existingAirport);
            await repo.SaveChangesAsync();
            return mapper.Map<AirportDto>(existingAirport);
        }
    }
}
