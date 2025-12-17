using DomainLayer.Models.Booking_Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Booking
{
    public interface ITourBookingRepository
    {
        Task<TourBooking> CreateAsync(TourBooking tourBooking);
        Task<TourBooking?> GetByBookingIdAsync(int bookingId);
        Task<TourBooking?> GetBookingTourByIdAsync(int bookingId);
        Task<bool> UpdateAsync(TourBooking tourBooking);
        Task<bool> DeleteAsync(int bookingId);
    }
}
