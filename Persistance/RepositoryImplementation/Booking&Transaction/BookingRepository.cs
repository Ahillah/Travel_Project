using DomainLayer.Models.Booking_Transaction;
using DomainLayer.RepositoryInterface.Booking_Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.RepositoryImplementation.Booking_Transaction
{
    public class BookingRepository:GenericRepository<Booking,int>,IBookingRepository
    {
        private readonly ApplicationDbContext dbContext;

        public BookingRepository(ApplicationDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
