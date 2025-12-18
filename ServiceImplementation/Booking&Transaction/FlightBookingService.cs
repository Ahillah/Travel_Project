using AutoMapper;
using DomainLayer.Models.Booking_Transaction;
using DomainLayer.RepositoryInterface.Booking_Transaction;
using ServiceAbstraction.Booking_Transaction;
using Shared.Dto_s.Booking_TransactionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ServiceImplementation.Booking_Transaction
{
    public class FlightBookingService:IFlightBookingService
    {
        private readonly IFlightBookingRepository repo;
        private readonly IBookingRepository bookingRepository;
        private readonly IMapper mapper;

        public FlightBookingService(IFlightBookingRepository repo,IBookingRepository bookingRepository,IMapper mapper)
        {
            this.repo = repo;
            this.bookingRepository = bookingRepository;
            this.mapper = mapper;
        }

        public async Task<FlightBookingDto?> GetByBookingIdAsync(int bookingId)
        {
          var FlightBooking= await repo.GetByBookingIdAsync(bookingId);
            if (FlightBooking == null)
            {
                return null;
            }
            return mapper.Map<FlightBookingDto>(FlightBooking);
            
        }
        public async Task<IEnumerable<FlightBookingDto>> GetByFlightIdAsync(int flightId)
        {
            var FlightBookings = await repo.GetByFlightIdAsync(flightId);
            if(FlightBookings == null)
                return Enumerable.Empty<FlightBookingDto>();
            return mapper.Map<IEnumerable<FlightBookingDto>>(FlightBookings);
        }
        public async Task<FlightBookingDto> CreateFlightBookingAsync(FlightBookingCreateDto dto)
        {
            var booking = new Booking
            {
                UserId = dto.UserId,
                BookingType = "Flight",
                Status = "Pending",
                TotalPrice = dto.TotalPrice
            };
          await  bookingRepository.Add(booking);
            await bookingRepository.SaveChangesAsync();
            var flightBooking = new FlightBooking
            {
                BookingId = booking.Id,
                FlightId = dto.FlightId,
                PassengerDetails = dto.PassengerDetails,
                SeatNumber = dto.SeatNumber,
                FareClass = dto.FareClass
            };

            await repo.Add(flightBooking);
            await repo.SaveChangesAsync();
            return mapper.Map<FlightBookingDto>(flightBooking);

        }

        public async Task<bool> DeleteFlightBookingAsync(int bookingId)
        {
            var flightBooking = await repo.GetByBookingIdAsync(bookingId);
            if (flightBooking == null)
                return false;

            
            repo.Delete(flightBooking);

           
             bookingRepository.Delete(flightBooking.Booking);

            await repo.SaveChangesAsync();
            await bookingRepository.SaveChangesAsync();

            return true;
        }
       public async Task<FlightBookingDto?> UpdateFlightBookingAsync(int bookingId, FlightBookingUpdateDto dto)
        {
            var flightBooking = await repo.GetByBookingIdAsync(bookingId);
            if (flightBooking == null)
                return null;
            flightBooking.SeatNumber = dto.SeatNumber;
            flightBooking.FareClass = dto.FareClass;
            flightBooking.Booking.Status = dto.Status;
            flightBooking.PassengerDetails= dto.PassengerDetails;
             repo.Update(flightBooking);
            await repo.SaveChangesAsync();
            return mapper.Map<FlightBookingDto>(flightBooking);
        }
        
    }
}
