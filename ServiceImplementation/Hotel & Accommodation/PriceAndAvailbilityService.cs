using AutoMapper;
using DomainLayer.Models.Hotels___Accommodation;
using DomainLayer.RepositoryInterface.Hotel___Accommodation;
using ServiceAbstraction.Hotel___Accommodation;
using Shared.Dto_s.Hotel___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ServiceImplementation.Hotel___Accommodation
{
    public class PriceAndAvailbilityService : IPriceAndAvailbilityService
    {
        private readonly IPriceAndAvailabilityRepository _priceAndAvailbilityRepo;
        private readonly IMapper mapper;
        public PriceAndAvailbilityService(IPriceAndAvailabilityRepository priceAndAvailbilityRepo, IMapper mapper)
        {
            _priceAndAvailbilityRepo = priceAndAvailbilityRepo;
            this.mapper = mapper;
        }


        //public async Task<bool> DeleteAsync(int roomId, DateTime date)
        //{
        //    await _priceAndAvailbilityRepo.DeleteAsync(roomId, date);
        //    return await _priceAndAvailbilityRepo.SaveAsync();
        //}
        public async Task<bool> DeleteAsync(int roomId, DateTime date)
        {
            var deleted = await _priceAndAvailbilityRepo.DeleteAsync(roomId, date);

            if (!deleted) return false;

            return await _priceAndAvailbilityRepo.SaveAsync();
        }

        public async Task<PriceAndAvailabilityDto> CreateAsync(PriceAndAvailabilityDto dto)
        {
            var entity = mapper.Map<PricesAndAvailability>(dto);
            var created = await _priceAndAvailbilityRepo.AddAsync(entity);
            return mapper.Map<PriceAndAvailabilityDto>(created);
        }

        public async Task<IEnumerable<PriceAndAvailabilityDto>> GetAllAsync()
        {
            var list = await _priceAndAvailbilityRepo.GetAllAsync();
            return mapper.Map<IEnumerable<PriceAndAvailabilityDto>>(list);
        }

        public async Task<PriceAndAvailabilityDto> GetByIdAsync(int roomId, DateTime date)
        {
            var entity = await _priceAndAvailbilityRepo.GetByIdAsync(roomId, date);
            if (entity == null)
            {
                return null;
            }
            return mapper.Map<PriceAndAvailabilityDto>(entity);
        }

        public async Task<bool> UpdateAsync(int roomId, DateTime date, PriceAndAvailabilityDto dto)
        {
            var entity = await _priceAndAvailbilityRepo.GetByIdAsync(roomId, date);
            if (entity == null) return false;

            mapper.Map(dto, entity);

            entity.RoomId = roomId; // keep keys correct
            entity.Date = date;

            return await _priceAndAvailbilityRepo.Update(entity);
        }

        public async Task<IEnumerable<PriceAndAvailabilityDto>> GetByRoom(int roomId)
        {
            var list = await _priceAndAvailbilityRepo.GetByRoom(roomId);
            return mapper.Map<IEnumerable<PriceAndAvailabilityDto>>(list);
        }


        public async Task<IEnumerable<RoomAvailabilityDto>> GetRoomAvailabilityAsync(int propertyId, DateTime start, DateTime end)
        {
            var data = await _priceAndAvailbilityRepo.GetRoomAvailabilityAsync(propertyId, start, end);

            return mapper.Map<IEnumerable<RoomAvailabilityDto>>(data);
        }


    }
}
