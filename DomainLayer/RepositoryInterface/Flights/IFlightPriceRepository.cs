using DomainLayer.Models.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Flights
{
    public interface IFlightPriceRepository:IGenericRepository<FlightPrice,int>
    {
        Task<FlightPrice?> GetPriceByClassAsync(int flightId, string className);
      
   
    }
}
