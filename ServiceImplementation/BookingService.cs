using AutoMapper;
using DomainLayer.Models.Booking_Transaction;
using DomainLayer.RepositoryInterface;
using ServiceAbstraction;
using Shared.Dto_s;
using Shared.Dto_s.Booking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation
{
   public class BookingService : IBookingService
    {
       
            private readonly IGenericRepository<Booking ,int> _bookingRepo;
            private readonly IMapper _mapper;

            public BookingService(
                IGenericRepository<Booking ,int> bookingRepo,
                IMapper mapper)
            {
                _bookingRepo = bookingRepo;
                _mapper = mapper;
            }

            // ============================
            // Create Booking
            // ============================
            public async Task<BookingDto> CreateAsync(string userId, CreateBookingDto dto)
            {
                var booking = new Booking
                {
                    UserId = userId,
                    BookingType = dto.BookingType,
                    TotalPrice = dto.TotalPrice,
                    Status = "Pending",
                    BookingDate = DateTime.UtcNow ,
                    ClientSecret = Guid.NewGuid().ToString() ,
                    PaymentIntentId = Guid.NewGuid().ToString() ,
                    PaymentStatus= "Pending"
                };
       
            await _bookingRepo.Add(booking);
              await  _bookingRepo.SaveChangesAsync();

                return _mapper.Map<BookingDto>(booking);
            }

            // ============================
            // Get Booking By Id
            // ============================
            public async Task<BookingDto> GetByIdAsync(int id)
            {
                var booking = await _bookingRepo.GetByIdAsync(id);

                if (booking == null)
                    throw new Exception("Booking not found");

                return _mapper.Map<BookingDto>(booking);
            }

            // ============================
            // Get All Bookings For User
            // ============================
            public async Task<IReadOnlyList<BookingDto>> GetUserBookingsAsync(string userId)
            {
                var bookings = await _bookingRepo.GetAllAsync();

                var userBookings = bookings
                    .Where(b => b.UserId == userId)
                    .ToList();

                return _mapper.Map<IReadOnlyList<BookingDto>>(userBookings);
            }

            // ============================
            // Update Booking
            // ============================
            public async Task<BookingDto> UpdateAsync(
                int bookingId,
                string userId,
                UpdateBookingDto dto)
            {
                var booking = await _bookingRepo.GetByIdAsync(bookingId);

                if (booking == null)
                    throw new Exception("Booking not found");

                // Authorization
                if (booking.UserId != userId)
                    throw new Exception("Not authorized to update this booking");

                // Business rule
                if (booking.Status == "Cancelled")
                    throw new Exception("Cancelled booking cannot be updated");

                booking.TotalPrice = dto.TotalPrice;
                booking.Status = dto.Status;

                 _bookingRepo.Update(booking);
            await _bookingRepo.SaveChangesAsync();

            return _mapper.Map<BookingDto>(booking);
            }

            // ============================
            // Cancel Booking 
            // ============================
            public async Task<bool> CancelAsync(int bookingId, string userId)
            {
                var booking = await _bookingRepo.GetByIdAsync(bookingId);

                if (booking == null)
                    return false;

                if (booking.UserId != userId)
                    throw new Exception("Not authorized to cancel this booking");

                booking.Status = "Cancelled";

                 _bookingRepo.Update(booking);
                await _bookingRepo.SaveChangesAsync();
            return true;
            }
        }

    }

