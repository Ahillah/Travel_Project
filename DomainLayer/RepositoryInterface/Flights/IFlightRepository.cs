using DomainLayer.Models.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Flights
{
    public interface IFlightRepository:IGenericRepository<Flight,int>
    {
        Task<List<Flight>> SearchFlightsAsync(int departureAirportId, int arrivalAirportId, DateTime date);
        // هجيب الرحلة وسعرها
        Task<Flight?> GetFlightDetailsWithPricesAsync(int flightId);
        // هل لو حجزت رحلة مثلا هل اصلا متوافر ععد الكراسي ولا لا وهستخمها في كل مرة هاجي احجز رحلة
        Task<bool> CheckAvailabilityAsync(int flightId, int passengerCount);
        Task<Flight?> GetFlightWithAirportsAndAirlineAsync(int flightId);


    }
}
