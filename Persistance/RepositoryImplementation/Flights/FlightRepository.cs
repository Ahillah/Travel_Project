using DomainLayer.Models.Flights;
using DomainLayer.RepositoryInterface.Flights;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.RepositoryImplementation.Flights
{
    public class FlightRepository : GenericRepository<Flight, int>, IFlightRepository
    {
        private readonly ApplicationDbContext dbContext;

        public FlightRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<bool> CheckAvailabilityAsync(int flightId, int passengerCount)
        {
            var flight = await dbContext.Flights
           .Include(f => f.FlightBookings) 
           .FirstOrDefaultAsync(f => f.Id == flightId);
            if (flight == null)
            {
                return false;
            }
      int seatsBooked = flight.FlightBookings.Count();
            int availableSeats = flight.TotalCapacity - seatsBooked;
            return availableSeats >= passengerCount;
        }

        public async Task<Flight?> GetFlightDetailsWithPricesAsync(int flightId)
        {
            return await dbContext.Flights.
                Include(F => F.Prices).
                FirstOrDefaultAsync(F => F.Id == flightId);
        }

        public async Task<Flight?> GetFlightWithAirportsAndAirlineAsync(int flightId)
        {
            return await dbContext.Flights.Include(F=>F.Airline)
                .Include(F=>F.DepartureAirport)
                .Include(F=>F.ArrivalAirport)
                .FirstOrDefaultAsync(F=>F.Id== flightId);
        }

        public async Task<List<Flight>> SearchFlightsAsync(int departureAirportId, int arrivalAirportId, DateTime date)
        { //عشان مانجيبش الداتا كلها من الداتا بيز قبل تطبيق الشروط
            var query = dbContext.Flights.AsQueryable();
            query = query
        .Include(f => f.Airline)        
        .Include(f => f.DepartureAirport) 
        .Include(f => f.ArrivalAirport);
            query = query.Where(f => f.DepartureAirportId == departureAirportId);
            query=query.Where(f=>f.ArrivalAirportId == arrivalAirportId);
            query= query.Where(f=>f.DepartureTime.Date==date.Date);
            return await query.ToListAsync();
        }
    }
}
