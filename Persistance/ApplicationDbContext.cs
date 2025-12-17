using DomainLayer.Models.Booking_Transaction;
using DomainLayer.Models.Flights;
using DomainLayer.Models.Flights;
using DomainLayer.Models.Hotels___Accommodation;
using DomainLayer.Models.Identity;
using DomainLayer.Models.Tours;
using DomainLayer.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistance.Configuration.Tour;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
    {




        public DbSet<Payment> Payment { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<HotelAmenity> HotelAmenities { get; set; }
        public DbSet<PricesAndAvailability> PricesAndAvailability { get; set; }


        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightPrice> FlightPrices { get; set; }
        public DbSet<FlightOffer> FlightOffers { get; set; }


        public DbSet<Tours> Tours { get; set; }
        public DbSet<TourDate> TourDates { get; set; }
        public DbSet<TourItinerary> TourItineraries { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<TourDestination> TourDestinations { get; set; }
        public DbSet<TourInclusion> TourInclusions { get; set; }


        public DbSet<Booking> Bookings { get; set; }
        public DbSet<HotelBooking> HotelBookings { get; set; }
        public DbSet<FlightBooking> FlightBookings { get; set; }
        public DbSet<TourBooking> TourBookings { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles");

            modelBuilder.ApplyConfiguration(new TourInclusionConfiguration());
            modelBuilder.ApplyConfiguration(new TourConfiguration());
            modelBuilder.ApplyConfiguration(new TourItineraryConfiguration());
            modelBuilder.ApplyConfiguration(new TourDateConfiguration());
            modelBuilder.ApplyConfiguration(new TourDestinationConfiguration());
            modelBuilder.ApplyConfiguration(new DestinationConfiguration());

            // جداول Identity
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            // المفاتيح المركبة
            modelBuilder.Entity<HotelAmenity>().HasKey(ha => new { ha.HotelId, ha.AmenityId });
            modelBuilder.Entity<TourDestination>().HasKey(td => new { td.TourId, td.DestinationId });
            modelBuilder.Entity<PricesAndAvailability>().HasKey(pa => new { pa.RoomId, pa.Date });

            // علاقات One-to-One للحجوزات المتخصصة
            modelBuilder.Entity<HotelBooking>()
                .HasOne(hb => hb.Booking).WithOne(b => b.HotelBooking).HasForeignKey<HotelBooking>(hb => hb.BookingId);
            modelBuilder.Entity<FlightBooking>()
                .HasOne(fb => fb.Booking).WithOne(b => b.FlightBooking).HasForeignKey<FlightBooking>(fb => fb.BookingId);
            modelBuilder.Entity<TourBooking>()
                .HasOne(tb => tb.Booking).WithOne(b => b.TourBooking).HasForeignKey<TourBooking>(tb => tb.BookingId);


            modelBuilder.Entity<Flight>()
                .HasOne(f => f.DepartureAirport).WithMany(a => a.DepartingFlights).HasForeignKey(f => f.DepartureAirportId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.ArrivalAirport).WithMany(a => a.ArrivingFlights).HasForeignKey(f => f.ArrivalAirportId).OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<FlightOffer>()
                .HasOne(fo => fo.Flight).WithMany(f => f.FlightOffers).HasForeignKey(fo => fo.FlightId).IsRequired(false);
            modelBuilder.Entity<FlightOffer>()
                .HasOne(fo => fo.Airline).WithMany(a => a.FlightOffers).HasForeignKey(fo => fo.AirlineId).IsRequired(false);
            modelBuilder.Entity<FlightOffer>()
                .HasOne(fo => fo.ArrivalAirport).WithMany(a => a.TargetedOffers).HasForeignKey(fo => fo.ArrivalAirportId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<HotelUser>()
                .HasOne(hu => hu.Hotel)
                .WithMany()
                .HasForeignKey(hu => hu.HotelId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<HotelBooking>()
                .HasOne(hb => hb.Room)
                .WithMany()
                .HasForeignKey(hb => hb.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FlightBooking>()
                .HasOne(fb => fb.Flight)
                .WithMany()
                .HasForeignKey(fb => fb.FlightId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TourBooking>()
                .HasOne(tb => tb.TourDate)
                .WithMany()
                .HasForeignKey(tb => tb.TourDateId)
                .OnDelete(DeleteBehavior.Restrict);

            // علاقات الدفع والمعاملات
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Transaction)
                .WithOne(t => t.Payment)
                .HasForeignKey<Payment>(p => p.TransactionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithMany()
                .HasForeignKey(p => p.BookingId)
                .OnDelete(DeleteBehavior.Restrict);


    
            modelBuilder.Entity<Booking>()
                .HasOne<TouristUser>().WithMany(u => u.Bookings).HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.Restrict);

          
            modelBuilder.Entity<Review>()
                .HasOne<TouristUser>().WithMany(u => u.Reviews).HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Restrict);

           
            modelBuilder.Entity<Payment>()
                .HasOne<TouristUser>().WithMany(u => u.Payments).HasForeignKey(pm => pm.UserId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}