using DomainLayer.Models.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Flights
{
    public interface IAirlineRepository:IGenericRepository<Airline,int>
    {
        Task<Airline?> GetByIATA_CodeAsync(string iataCode);
      
        // part of name or iata code
        Task<IEnumerable<Airline>> SearchAirlinesAsync(string? searchValue);
       
    }
}
