using AutoMapper;
using DomainLayer.Models.Booking_Transaction;
using DomainLayer.Models.Hotels___Accommodation;
using DomainLayer.RepositoryInterface.Hotel___Accommodation;
using Microsoft.EntityFrameworkCore;
using ServiceAbstraction.Hotel___Accommodation;
using Shared.Dto_s.Hotel___Accommodation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.Hotel___Accommodation
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepo;
        private readonly IMapper _mapper;
        public HotelService(IHotelRepository hotelRepo, IMapper mapper)
        {
            _hotelRepo = hotelRepo;
            _mapper = mapper;
        }

        public async Task<HotelDto> CreateAsync(HotelDto dto)
        {
            var entity = _mapper.Map<Hotel>(dto);
            var created = await _hotelRepo.AddAsync(entity);
            return _mapper.Map<HotelDto>(created);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingHotel = await _hotelRepo.GetByIdAsync(id);
            if (existingHotel == null)
            {
                return false;
            }
            return await _hotelRepo.DeleteAsync(id);
        }



        public async Task<IEnumerable<HotelDto>> GetAllAsync()
        {
            var hotels = await _hotelRepo.GetAllAsync();

            return _mapper.Map<IEnumerable<HotelDto>>(hotels);
        }

        public async Task<HotelDto> GetByIdAsync(int id)
        {
            var h = await _hotelRepo.GetByIdAsync(id);
            if (h == null) return null;
            return _mapper.Map<HotelDto>(h);
        }

   

        public async Task<bool> UpdateAsync(int id, HotelDto dto)
        {
            var hotel = await _hotelRepo.GetByIdAsync(id);
            if (hotel == null) return false;

            _mapper.Map(dto, hotel); // Id will not be touched

            return await _hotelRepo.UpdateAsync(hotel);
        }

        public async Task<IEnumerable<HotelDto>> GetHotelsByCityAsync(string city)
        {
            var hotels = await _hotelRepo.GetHotelsByCityAsync(city);
            return _mapper.Map<IEnumerable<HotelDto>>(hotels);
        }

        public async Task<IEnumerable<HotelDto>> SearchPropertiesAsync(string location, DateTime checkIn, DateTime checkOut, int guests)
        {
            var hotels = await _hotelRepo.SearchHotelsAsync(location, checkIn, checkOut, guests);

            return _mapper.Map<IEnumerable<HotelDto>>(hotels);
        }
        public async Task<HotelDetailsDto> GetPropertyDetailsAsync(int propertyId)
        {
            var hotel = await _hotelRepo.GetPropertyDetailsAsync(propertyId);

            return _mapper.Map<HotelDetailsDto>(hotel);
        }
        public async Task<IEnumerable<HotelDto>> GetSimilarPropertiesAsync(int propertyId)
        {
            var hotels = await _hotelRepo.GetSimilarPropertiesAsync(propertyId);
            return hotels.Select(h => new HotelDto { Id = h.Id, Name = h.Name });
        }


    }

}
