using AutoMapper;
using DomainLayer.Models.Booking_Transaction;
using DomainLayer.RepositoryInterface.Booking_Transaction;
using ServiceAbstraction.Booking_Transaction;
using Shared.Dto_s.Booking_Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.Booking_Transaction
{
    public class HotelBookingService : IHotelBookingService
    {
        private readonly IHotelBookingRepository _repo;
        private readonly IMapper _mapper;
        public HotelBookingService(IHotelBookingRepository hotelBookingRepository, IMapper mapper)
        {
            _repo = hotelBookingRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<HotelBookingDto>> GetBookingAllAsync()
        {
            var data = await _repo.GetAllBookingAsync();
            return _mapper.Map<IEnumerable<HotelBookingDto>>(data);
        }

        public async Task<HotelBookingDto> GetBookingByIdAsync(int bookingId)
        {
            var entity = await _repo.GetBookingByIdAsync(bookingId);
            return _mapper.Map<HotelBookingDto>(entity);
        }
        public async Task<HotelBookingDto> AddBookingAsync(HotelBookingDto dto)
        {
            var entity = _mapper.Map<HotelBooking>(dto);
            var created = await _repo.AddBookingAsync(entity);
            return _mapper.Map<HotelBookingDto>(created);
        }

        public async Task<bool> UpdateBookingAsync(int bookingId, HotelBookingDto dto)
        {
            var entity = await _repo.GetBookingByIdAsync(bookingId);
            if (entity == null) return false;

            _mapper.Map(dto, entity);
            return await _repo.UpdateBookingAsync(entity);
        }

        public async Task<bool> DeleteBookingAsync(int bookingId)
        {
            return await _repo.DeleteBookingAsync(bookingId);
        }
        public async Task<IEnumerable<HotelBookingDto>> GetBookingsByRoomAsync(int roomId)
        {
            var data = await _repo.GetBookingsByRoomAsync(roomId);
            return _mapper.Map<IEnumerable<HotelBookingDto>>(data);
        }
    }
}
