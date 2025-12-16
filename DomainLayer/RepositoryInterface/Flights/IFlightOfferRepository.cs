using DomainLayer.Models.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Flights
{
    public interface IFlightOfferRepository:IGenericRepository<FlightOffer,int>
    {
        Task<IEnumerable<FlightOffer>> GetAllOffersWithDetailsAsync();
        Task<FlightOffer?> GetOfferWithDetailsAsync(int id);
        Task<IEnumerable<FlightOffer>> GetActiveOffersAsync(DateTime today);
        Task<IEnumerable<FlightOffer>> GetOffersByDestinationAsync(int arrivalAirportId);
       
    }
}
