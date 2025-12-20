using DomainLayer.Models.Booking_Transaction;
using DomainLayer.Models.Identity;
using DomainLayer.RepositoryInterface;
using Microsoft.Extensions.Configuration;
using ServiceAbstraction;
using Stripe;
using System.Linq;


namespace ServiceImplementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IGenericRepository<Booking ,int> _bookingRepo;
        private readonly IGenericRepository<Payment, int> _paymentRepo;
        private readonly IGenericRepository<Transaction, int> _transactionRepo;

        public PaymentService(
            IConfiguration configuration,
            IGenericRepository<Booking, int> bookingRepo,
            IGenericRepository<Payment, int> paymentRepo,
            IGenericRepository<Transaction, int> transactionRepo)
        {
            _configuration = configuration;
            _bookingRepo = bookingRepo;
            _paymentRepo = paymentRepo;
            _transactionRepo = transactionRepo;
        }

        public async Task<Booking> CreateOrUpdatePaymentIntent(int bookingId)
        {
            StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];

            var booking = await _bookingRepo.GetByIdAsync(bookingId);
            if (booking == null) return null;

            long amount = (long)(booking.TotalPrice * 100);

            var service = new PaymentIntentService();
            PaymentIntent intent;

            if (string.IsNullOrEmpty(booking.PaymentIntentId))
            {
                var createOptions = new PaymentIntentCreateOptions
                {
                    Amount = amount,
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }
                };

                intent = await service.CreateAsync(createOptions);

                booking.PaymentIntentId = intent.Id;
                booking.ClientSecret = intent.ClientSecret;
                booking.PaymentStatus = "Pending";

                var payment = new Payment
                {
                    BookingId = booking.Id,
                    UserId = booking.UserId,
                    Amount = booking.TotalPrice,
                    Status = "Pending",
                    PaymentMethod = "Stripe",
                    CreatedAt = DateTime.UtcNow
                };

                await _paymentRepo.Add(payment);
            }
            else
            {
                var updateOptions = new PaymentIntentUpdateOptions { Amount = amount };
                intent = await service.UpdateAsync(booking.PaymentIntentId, updateOptions);
            }

             _bookingRepo.Update(booking);
            return booking;
        }

        public async Task<bool> UpdatePaymentStatus(string paymentIntentId, bool isPaid)
        {
            var booking = (await _bookingRepo.GetAllAsync())
                .FirstOrDefault(x => x.PaymentIntentId == paymentIntentId);

            if (booking == null) return false;

            var payment = (await _paymentRepo.GetAllAsync())
                .FirstOrDefault(x => x.BookingId == booking.Id);

            if (payment == null) return false;

            payment.Status = isPaid ? "Paid" : "Failed";
            booking.PaymentStatus = isPaid ? "Paid" : "Failed";

          _paymentRepo.Update(payment);
          _bookingRepo.Update(booking);

            if (isPaid)
            {
                var transaction = new Transaction
                {
                    BookingId = booking.Id,
                    PaymentId = payment.Id,
                    Amount = payment.Amount,
                    Status = "Completed",
                    PaymentMethod = payment.PaymentMethod,
                    PaymentIntentId = booking.PaymentIntentId,
                    TransactionDate = DateTime.UtcNow
                };
                await _transactionRepo.Add(transaction);
            }

            return true;
        }


        //public async Task<bool> ConfirmPayment(string paymentIntentId)
        //{
        //    StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];

        //    var service = new PaymentIntentService();

        //    try
        //    {
        //        // Confirm Payment on Stripe
        //        var intent = await service.ConfirmAsync(paymentIntentId);

        //        bool isPaid = intent.Status == "succeeded";

        //        // Update DB Status
        //        var booking = (await _bookingRepo.GetAllAsync())
        //            .FirstOrDefault(x => x.PaymentIntentId == paymentIntentId);

        //        if (booking == null)
        //            return false;

        //        booking.Status = isPaid ? "Paid" : "Failed";
        //        _bookingRepo.Update(booking);

        //        var payment = (await _paymentRepo.GetAllAsync())
        //            .FirstOrDefault(x => x.BookingId == booking.Id);

        //        if (payment != null)
        //        {
        //            payment.Status = isPaid ? "Paid" : "Failed";
        //           _paymentRepo.Update(payment);
        //        }

        //        return isPaid;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Payment Confirmation Error: " + ex.Message);
        //        return false;
        //    }
        //}

        public async Task HandleSuccessfulPayment(string paymentIntentId)
        {


            var booking = (await _bookingRepo.GetAllAsync())
             .FirstOrDefault(b => b.PaymentIntentId == paymentIntentId);

            if (booking == null)
                return;
            var payment = (await _paymentRepo.GetAllAsync())
             .FirstOrDefault(p => p.BookingId == booking.Id);

            if (payment == null)
                return;
            payment.Status = "Paid";
            _paymentRepo.Update(payment);

            booking.PaymentStatus = "Paid";
            booking.Status = "Confirmed";
            _bookingRepo.Update(booking);

            // Create Transaction
            var transaction = new Transaction
            {
                PaymentIntentId = paymentIntentId,
                Amount = payment.Amount,
                PaymentMethod = payment.PaymentMethod,
                Status = "Completed",
                BookingId = booking.Id,
                PaymentId = payment.Id
            };

            await _transactionRepo.Add(transaction);


        }

        public async Task<bool> ConfirmPayment(string paymentIntentId)
        {
            StripeConfiguration.ApiKey = _configuration["StripeSettings:SecretKey"];
            var service = new PaymentIntentService();

            try
            {
                // تحقق من حالة الـ PaymentIntent قبل Confirm
                var existingIntent = await service.GetAsync(paymentIntentId);

                if (existingIntent.Status == "succeeded")
                {
                    Console.WriteLine("PaymentIntent already succeeded. Skipping Confirm.");
                    // تحديث DB لو محتاج
                    var booking = (await _bookingRepo.GetAllAsync())
                        .FirstOrDefault(x => x.PaymentIntentId == paymentIntentId);

                    if (booking != null)
                    {
                        booking.Status = "Paid";
                        booking.PaymentStatus = "Paid";
                        _bookingRepo.Update(booking);
                    }

                    return true;
                }

                // Confirm الدفع باستخدام Test Card (Test Mode)
                var intent = await service.ConfirmAsync(paymentIntentId, new PaymentIntentConfirmOptions
                {
                    PaymentMethod = "pm_card_visa"
                });

                bool isPaid = intent.Status == "succeeded";

                // تحديث DB
                var bookingDb = (await _bookingRepo.GetAllAsync())
                    .FirstOrDefault(x => x.PaymentIntentId == paymentIntentId);

                if (bookingDb != null)
                {
                    bookingDb.Status = isPaid ? "Paid" : "Failed";
                    bookingDb.PaymentStatus = isPaid ? "Paid" : "Failed";
                    _bookingRepo.Update(bookingDb);
                }

                var payment = (await _paymentRepo.GetAllAsync())
                    .FirstOrDefault(x => x.BookingId == bookingDb?.Id);

                if (payment != null)
                {
                    payment.Status = isPaid ? "Paid" : "Failed";
                    _paymentRepo.Update(payment);
                }

                if (isPaid)
                {
                    var transaction = new Transaction
                    {
                        BookingId = bookingDb?.Id ?? 0,
                        PaymentId = payment?.Id ?? 0,
                        Amount = payment?.Amount ?? bookingDb?.TotalPrice ?? 0,
                        Status = "Completed",
                        PaymentMethod = payment?.PaymentMethod ?? "Stripe",
                        PaymentIntentId = paymentIntentId,
                        TransactionDate = DateTime.UtcNow
                    };
                    await _transactionRepo.Add(transaction);
                }

                return isPaid;
            }
            catch (StripeException stripeEx)
            {
                Console.WriteLine("Stripe Error: " + stripeEx.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("General Payment Error: " + ex.Message);
                return false;
            }
        }

    }

}





