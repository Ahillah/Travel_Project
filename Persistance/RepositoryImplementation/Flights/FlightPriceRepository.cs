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
    public class FlightPriceRepository : GenericRepository<FlightPrice, int>, IFlightPriceRepository
    {
        private readonly ApplicationDbContext dbContext;

        public FlightPriceRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
       

        public async Task<FlightPrice?> GetPriceByClassAsync(int flightId, string className)
        {
            return await dbContext.FlightPrices.FirstOrDefaultAsync(f => f.FlightId == flightId&& f.Class==className);
        }
    }
}
