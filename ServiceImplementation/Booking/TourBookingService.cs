using AutoMapper;
using DomainLayer.Models.Booking_Transaction;
using DomainLayer.RepositoryInterface.Booking;
using ServiceAbstraction.Booking;
using Shared.Dto_s.Booking.TourBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.Booking
{
    public class TourBookingService : ITourBookingService
    {
        private readonly ITourBookingRepository _repo;
        private readonly IMapper _mapper;

        public TourBookingService(ITourBookingRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<TourBookingDto> CreateAsync(CreateTourBookingDto dto)
        {
            var entity = _mapper.Map<TourBooking>(dto);
            var result = await _repo.CreateAsync(entity);
            return _mapper.Map<TourBookingDto>(result);
        }
        public async Task<TourBookingDto?> GetByBookingIdAsync(int bookingId)
        {
            var result = await _repo.GetByBookingIdAsync(bookingId);
            return result == null ? null : _mapper.Map<TourBookingDto>(result);
        }
        public async Task<BookingTourDto?> GetBookingTourByIdAsync(int bookingId)
        {
            var result = await _repo.GetBookingTourByIdAsync(bookingId);
            return result == null ? null : _mapper.Map<BookingTourDto>(result);
        }
        public async Task<bool> UpdateAsync(int bookingId, UpdateTourBookingDto dto)
        {
            var booking = await _repo.GetByBookingIdAsync(bookingId);
            if (booking == null) return false;

            booking.NumberOfPeople = dto.NumberOfPeople;
            return await _repo.UpdateAsync(booking);
        }
        public async Task<bool> DeleteAsync(int bookingId)
        {
            return await _repo.DeleteAsync(bookingId);
        }
    }
}
