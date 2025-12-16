using DomainLayer.Models.Booking_Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.RepositoryInterface.Booking_Transaction
{
    public interface IBookingRepository:IGenericRepository<Booking,int>
    {
    }
}
