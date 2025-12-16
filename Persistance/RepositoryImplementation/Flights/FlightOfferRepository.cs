using DomainLayer.Models.Flights;
using DomainLayer.RepositoryInterface;
using DomainLayer.RepositoryInterface.Flights;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.RepositoryImplementation.Flights
{
    public class FlightOfferRepository: GenericRepository<FlightOffer,int>,IFlightOfferRepository
    {
        private readonly ApplicationDbContext dbContext;

        public FlightOfferRepository(ApplicationDbContext dbContext):base(dbContext) 
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<FlightOffer>> GetActiveOffersAsync(DateTime today)
        {
            return await dbContext.FlightOffers
                .Where(o => o.Flight != null && o.Flight.DepartureTime.Date >= today.Date)

                .Include(o => o.Airline)
                .Include(o => o.ArrivalAirport)

                .Include(o => o.Flight)
                    .ThenInclude(f => f.Airline)
                .Include(o => o.Flight)
                    .ThenInclude(f => f.DepartureAirport)
                .Include(o => o.Flight)
                    .ThenInclude(f => f.ArrivalAirport)

                .ToListAsync();
        }

        public async Task<IEnumerable<FlightOffer>> GetOffersByDestinationAsync(int arrivalAirportId)
        {
           return await dbContext.FlightOffers
                .Include(o => o.Airline)
        .Include(o => o.Flight)
        .Include(o => o.ArrivalAirport).Where(f=>f.ArrivalAirportId == arrivalAirportId).ToListAsync();
        }
        public async Task<IEnumerable<FlightOffer>> GetAllOffersWithDetailsAsync()
        {
            return await dbContext.FlightOffers
                .Include(o => o.Airline)
                .Include(o => o.Flight)
                .Include(o => o.ArrivalAirport)
                .ToListAsync();
        }
        public async  Task<FlightOffer?> GetOfferWithDetailsAsync(int id)
        {
            return await dbContext.FlightOffers
                .Where(f => f.Id == id)             
                .Include(o => o.Airline)
                .Include(o => o.Flight)
                .Include(o => o.ArrivalAirport)
                .FirstOrDefaultAsync();
        }
    }
}
