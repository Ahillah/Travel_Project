using DomainLayer;
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
    public class AirLineRepository : GenericRepository<Airline, int>, IAirlineRepository
    {
        private readonly ApplicationDbContext dbContext;

        public AirLineRepository(ApplicationDbContext dbContext):base(dbContext)
        {
         this.dbContext = dbContext;
        }
        public async Task<Airline?> GetByIATA_CodeAsync(string iataCode)
        {
           return await dbContext.Airlines.FirstOrDefaultAsync(a => a.IATA_Code == iataCode);
            //مش هينفع استخدم Where عشان بترجع IQuerable مش Airline
        }

        public async Task<IEnumerable<Airline>> SearchAirlinesAsync(string? searchValue)
        {
            if (searchValue != null)

            {
                var query = dbContext.Airlines.AsQueryable();

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
