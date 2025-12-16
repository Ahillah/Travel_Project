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
    public class AirportRepository : GenericRepository<Airport, int>, IAirportRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AirportRepository(ApplicationDbContext dbContext):base(dbContext) {
            this.dbContext = dbContext;
        }


        public async Task<Airport?> GetAirportWithFlightsAsync(int id)
        {
            return await dbContext.Airports
                .Where(a => a.Id == id)

               
                .Include(a => a.DepartingFlights)
                    .ThenInclude(f => f.Airline)
                .Include(a => a.DepartingFlights)
                    .ThenInclude(f => f.ArrivalAirport)

                .Include(a => a.ArrivingFlights)
                    .ThenInclude(f => f.Airline)
                .Include(a => a.ArrivingFlights)
                    .ThenInclude(f => f.DepartureAirport)
                         .Include(a => a.TargetedOffers)
          .ThenInclude(o => o.Airline)
          .Include(a => a.TargetedOffers)

                .FirstOrDefaultAsync();
        }
        public async Task<Airport?> GetAirportWithOffersAsync(int id)
        {
            return await dbContext.Airports
          .Where(a => a.Id == id)
          .Include(a => a.TargetedOffers)
          .ThenInclude(o => o.Airline)
          .Include(a => a.TargetedOffers)
              .ThenInclude(o => o.Flight)
          .FirstOrDefaultAsync();
        }

        public async Task<Airport?> GetByIATA_CodeAsync(string iataCode)
        {
            return await dbContext.Airports.FirstOrDefaultAsync(a=>a.IATA_Code == iataCode);
        }

        public async Task<List<Airport>> SearchAirportsAsync(string searchValue)
        {

            if (searchValue != null)

            {
                var query = dbContext.Airports.AsQueryable();

                if (!string.IsNullOrEmpty(searchValue))
                {
                    string search = searchValue.ToLower();
                    query = query.Where(a =>
                   (a.Name != null &&
                        a.Name.ToLower().Contains(search)) ||
                      (a.IATA_Code != null &&
                      a.IATA_Code.ToLower().Contains(search))
                    );
                }

                return await query.ToListAsync();
            }
            return null;
        }
    }
}
