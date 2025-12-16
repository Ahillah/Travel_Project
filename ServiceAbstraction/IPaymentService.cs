using DomainLayer.Models.Booking_Transaction;
using DomainLayer.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IPaymentService
    {

        Task<Booking> CreateOrUpdatePaymentIntent(int bookingId);
        Task<bool> UpdatePaymentStatus(string paymentIntentId, bool isPaid);
        Task<bool> ConfirmPayment( string paymentIntentId);
        Task HandleSuccessfulPayment(string paymentIntentId);
    }
}
