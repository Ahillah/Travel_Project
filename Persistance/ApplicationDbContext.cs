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


        public DbSet<Tour> Tours { get; set; }
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

            // إعادة تسمية جداول Identity
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
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
                .HasOne(hb => hb.Booking)
                .WithOne(b => b.HotelBooking)
                .HasForeignKey<HotelBooking>(hb => hb.BookingId);

            modelBuilder.Entity<FlightBooking>()
                .HasOne(fb => fb.Booking)
                .WithOne(b => b.FlightBooking)
                .HasForeignKey<FlightBooking>(fb => fb.BookingId);

            modelBuilder.Entity<TourBooking>()
                .HasOne(tb => tb.Booking)
                .WithOne(b => b.TourBooking)
                .HasForeignKey<TourBooking>(tb => tb.BookingId);

            // علاقات الطيران
            modelBuilder.Entity<Flight>()
                .HasOne(f => f.DepartureAirport)
                .WithMany(a => a.DepartingFlights)
                .HasForeignKey(f => f.DepartureAirportId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.ArrivalAirport)
                .WithMany(a => a.ArrivingFlights)
                .HasForeignKey(f => f.ArrivalAirportId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FlightOffer>()
                .HasOne(fo => fo.Flight)
                .WithMany(f => f.FlightOffers)
                .HasForeignKey(fo => fo.FlightId)
                .IsRequired(false);

            modelBuilder.Entity<FlightOffer>()
                .HasOne(fo => fo.Airline)
                .WithMany(a => a.FlightOffers)
                .HasForeignKey(fo => fo.AirlineId)
                .IsRequired(false);

            modelBuilder.Entity<FlightOffer>()
                .HasOne(fo => fo.ArrivalAirport)
                .WithMany(a => a.TargetedOffers)
                .HasForeignKey(fo => fo.ArrivalAirportId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            // علاقات User مع Booking, Payment, Review
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User) // Navigation property
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User) // Navigation property
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User) // Navigation property
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .Property(r => r.TargetType)
                .HasConversion<string>();

            // علاقات Payment مع Transaction و Booking
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

            // علاقات HotelBooking مع Room
            modelBuilder.Entity<HotelBooking>()
                .HasOne(hb => hb.Room)
                .WithMany(r => r.HotelBookings) // navigation property جديدة
                .HasForeignKey(hb => hb.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            // علاقات TourBooking مع TourDate
            modelBuilder.Entity<TourBooking>()
                .HasOne(tb => tb.TourDate)
                .WithMany(td => td.TourBookings) // navigation property جديدة
                .HasForeignKey(tb => tb.TourDateId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}