using AutoMapper;
using DomainLayer.Models.Flights;
using DomainLayer.RepositoryInterface.Flights;
using ServiceAbstraction.flight;
using Shared.Dto_s.FlightDto.flight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.flight
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository repo;
        private readonly IMapper mapper;

        public FlightService(IFlightRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Flight_Dto>> GetAllFlightsAsync()
        {
            var Flights = await repo.GetAllAsync();
            if (Flights == null || !Flights.Any())
                return Enumerable.Empty<Flight_Dto>();
            return mapper.Map<IEnumerable<Flight_Dto>>(Flights);

        }
        public async Task<bool> CheckAvailabilityAsync(int flightId, int passengerCount)
        {
            return await  repo.CheckAvailabilityAsync(flightId, passengerCount);
        }

        public async Task<Flight_Dto> CreateFlightAsync(FlightCreatedDto dto)
        {
            var Flight= mapper.Map<DomainLayer.Models.Flights.Flight>(dto);
            await repo.Add(Flight);
            await repo.SaveChangesAsync();
            var createdFlightWithDetails = await repo.GetFlightWithAirportsAndAirlineAsync(Flight.Id);

      
            if (createdFlightWithDetails == null)
            {
                return mapper.Map<Flight_Dto>(Flight);
            }

            return mapper.Map<Flight_Dto>(createdFlightWithDetails);
          
        }

        public async Task<bool> DeleteFlightAsync(int id)
        {
           var Flight= await repo.GetByIdAsync(id);
            if (Flight == null)
            {return false;
            }
              repo.Delete(Flight);
            await repo.SaveChangesAsync();
            return true;
        }


        public async Task<FlightDetailsDto?> GetFlightDetailsAsync(int id)
        {
           var Flight= await repo.GetFlightWithAirportsAndAirlineAsync(id);
            if(Flight == null)
                {return null;}
            return mapper.Map<FlightDetailsDto>(Flight);
        }

        public async Task<FlightDetailsDto?> GetFlightWithPricesAsync(int id)
        {
            var Flight = await repo.GetFlightDetailsWithPricesAsync(id);
            if (Flight == null)
            { return null; }
            return mapper.Map<FlightDetailsDto>(Flight);

        }

        public async Task<IEnumerable<Flight_Dto>> SearchFlightsAsync(int departureAirportId, int arrivalAirportId, DateTime date)
        {
            var Flight = await repo.SearchFlightsAsync(departureAirportId, arrivalAirportId, date);
            if(Flight is  null)
                return Enumerable.Empty<Flight_Dto>();
            return mapper.Map<IEnumerable<Flight_Dto>>(Flight);
        }

        public async Task<Flight_Dto?> UpdateFlightAsync(int id, FlightUpdatedDto dto)
        {
            var Flight= await repo.GetByIdAsync(id);
            if(Flight == null)
                { return null; }
            mapper.Map(dto, Flight);
            repo.Update(Flight);
            await repo.SaveChangesAsync();
            return mapper.Map<Flight_Dto>(Flight);
        }

    }
}
