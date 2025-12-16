
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiceAbstraction;
using Shared.Dto_s.Payment;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IConfiguration _configuration;

        public PaymentController(IPaymentService paymentService , IConfiguration configuration)
        {
            _paymentService = paymentService;
            _configuration = configuration;

        }

        [HttpPost("create-intent/{bookingId}")]
        public async Task<IActionResult> CreateIntent(int bookingId)
        {
            var result = await _paymentService.CreateOrUpdatePaymentIntent(bookingId);

            if (result == null)
                return BadRequest("Booking not found");

            return Ok(new
            {
                clientSecret = result.ClientSecret,
                paymentIntentId = result.PaymentIntentId
            });
        }

        [HttpPost("confirm")]
        public async Task<IActionResult> ConfirmPayment([FromBody] ConfirmPaymentDto dto)
        {
            var success = await _paymentService.ConfirmPayment(dto.PaymentIntentId);

            if (!success)
                return BadRequest("Payment confirmation failed");

            return Ok(new
            {
                success = true,
                message = "Payment completed"
            });
        }

        // ==============================
        // Stripe Webhook
        // ==============================
        [HttpPost("stripe/webhook")]
        [AllowAnonymous]
        public async Task<IActionResult> StripeWebhook()
        {
            var json = await new StreamReader(Request.Body).ReadToEndAsync();

            var stripeEvent = EventUtility.ConstructEvent(
                json,
                Request.Headers["Stripe-Signature"],
                _configuration["Stripe:WebhookSecret"]
            );

            if (stripeEvent.Type == "payment_intent.succeeded")
            {
                var intent = (PaymentIntent)stripeEvent.Data.Object;

                await _paymentService.HandleSuccessfulPayment(intent.Id);
            }

            return Ok();
        }
    }

}

