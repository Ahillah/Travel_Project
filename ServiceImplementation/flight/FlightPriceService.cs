using AutoMapper;
using DomainLayer.Models.Flights;
using DomainLayer.RepositoryInterface.Flights;
using ServiceAbstraction.flight;
using Shared.Dto_s.FlightDto.FlightPrice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.flight
{
    public class FlightPriceService:IFlightPriceService
    {
        private readonly IFlightPriceRepository repo;
        private readonly IMapper mapper;

        public FlightPriceService(IFlightPriceRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<FlightPriceDto> CreatePriceAsync(FlightPriceCreatedDto dto)
        {
            var flightPrice = mapper.Map<FlightPrice>(dto);
            await repo.Add(flightPrice);
            await repo.SaveChangesAsync();
            return mapper.Map<FlightPriceDto>(flightPrice);
        }

        public async Task<bool> DeletePriceAsync(int id)
        {
            var flightPrice = await repo.GetByIdAsync(id);
            if (flightPrice == null)
            {
                return false;
            }
            repo.Delete(flightPrice);
            await repo.SaveChangesAsync();
            return true;
        }

        public async  Task<IEnumerable<FlightPriceDto>> GetAllPricesAsync()
        {
            var flightPrices = await repo.GetAllAsync();
            if (flightPrices == null)
                return Enumerable.Empty<FlightPriceDto>();

            return mapper.Map<IEnumerable<FlightPriceDto>>(flightPrices);
        }

        public async Task<FlightPriceDto?> GetPriceByClassAndFlightAsync(int flightId, string className)
        {
            var flightPrice = await repo.GetPriceByClassAsync(flightId, className);
            if (flightPrice == null)
            {
                return null;
            }
            return mapper.Map<FlightPriceDto>(flightPrice);
        }

        public async  Task<FlightPriceDto?> GetPriceByIdAsync(int id)
        {
            var flightPrice = await repo.GetByIdAsync(id);
            if (flightPrice == null)
                return null;
            return mapper.Map<FlightPriceDto>(flightPrice);
        }

        public async Task<FlightPriceDto?> UpdatePriceAsync(int id, FlightPriceUpdatedDto dto)
        {
            var flightPrice = await repo.GetByIdAsync(id);
            if (flightPrice == null)
            {
                return null;
            }

           
            mapper.Map(dto, flightPrice);

            repo.Update(flightPrice);
            await repo.SaveChangesAsync();

           
            return mapper.Map<FlightPriceDto>(flightPrice);
        }
    }
}
