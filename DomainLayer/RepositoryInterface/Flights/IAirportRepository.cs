using DomainLayer.Models.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Flights
{
    public interface IAirportRepository:IGenericRepository<Airport,int>
    {
        Task<Airport?> GetByIATA_CodeAsync(string iataCode);
        //search by name or code
        Task<List<Airport>> SearchAirportsAsync(string searchValue);
        Task<Airport?> GetAirportWithOffersAsync(int id);
        Task<Airport?> GetAirportWithFlightsAsync(int id);


    }
}
