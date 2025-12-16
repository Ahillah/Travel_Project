using AutoMapper;
using DomainLayer.Models.Flights;
using DomainLayer.RepositoryInterface.Flights;
using ServiceAbstraction.flight;
using Shared.Dto_s.FlightDto.flight;
using Shared.Dto_s.FlightDto.FlightOffer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.flight
{
    public class FlightOfferService : IFlightOfferService
    {
        private readonly IFlightOfferRepository repo;
        private readonly IMapper mapper;

        public FlightOfferService(IFlightOfferRepository repo , IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<FlightOfferDto> CreateOfferAsync(FlightOfferCreatedDto dto)
        {
            var FlightOffer = mapper.Map<FlightOffer>(dto);
            await repo.Add(FlightOffer);
            await repo.SaveChangesAsync();

            var createdOfferWithDetails = await repo.GetOfferWithDetailsAsync(FlightOffer.Id);

            if (createdOfferWithDetails != null)
            {
                return mapper.Map<FlightOfferDto>(createdOfferWithDetails);
            }

            return mapper.Map<FlightOfferDto>(FlightOffer);
        }

        public async Task<bool> DeleteOfferAsync(int id)
        {
            var FlightOffer = await repo.GetByIdAsync(id);
            if (FlightOffer == null)
                return false;
            repo.Delete(FlightOffer);
            await repo.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<FlightOfferDto>?> GetActiveOffersAsync(DateTime today)
        {
            var FlightOffers = await repo.GetActiveOffersAsync(today);
            if (FlightOffers is null || !FlightOffers.Any())
                return Enumerable.Empty<FlightOfferDto>();
            return mapper.Map<IEnumerable<FlightOfferDto>>(FlightOffers);
        }

        public async Task<IEnumerable<FlightOfferDto>> GetAllOffersAsync()
        {
            var FlightOffers = await repo.GetAllOffersWithDetailsAsync();

            if (FlightOffers is null || !FlightOffers.Any())
                return Enumerable.Empty<FlightOfferDto>();
            return mapper.Map<IEnumerable<FlightOfferDto>>(FlightOffers);
        }

        public async Task<FlightOfferDto?> GetOfferByIdAsync(int id)
        {
            var FlightOffer = await repo.GetOfferWithDetailsAsync(id);
            if (FlightOffer == null)
                return null;
            return mapper.Map<FlightOfferDto>(FlightOffer);
        }

        public async Task<IEnumerable<FlightOfferDto>?> GetOffersByDestinationAsync(int arrivalAirportId)
        {
            var FlightOffer = await repo.GetOffersByDestinationAsync(arrivalAirportId);
            if (FlightOffer == null || !FlightOffer.Any())
                return Enumerable.Empty<FlightOfferDto>();
            return mapper.Map<IEnumerable<FlightOfferDto>>(FlightOffer);
        }

        public async Task<FlightOfferDto?> UpdateOfferAsync(int id, FlightOfferUpdatedDto dto)
        {
            var FlightOffer = await repo.GetByIdAsync(id);
            if (FlightOffer == null)
                return null;

            mapper.Map(dto, FlightOffer);
            repo.Update(FlightOffer);
            await repo.SaveChangesAsync();

            var updatedOfferWithDetails = await repo.GetOfferWithDetailsAsync(id);

            if (updatedOfferWithDetails != null)
            {
                return mapper.Map<FlightOfferDto>(updatedOfferWithDetails);
            }
            return mapper.Map<FlightOfferDto>(FlightOffer);
        }
    }
}
