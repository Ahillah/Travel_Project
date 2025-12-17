using DomainLayer.Models.Tours;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Configuration.Tour
{
    public class TourItineraryConfiguration : IEntityTypeConfiguration<TourItinerary>
    {
        public void Configure(EntityTypeBuilder<TourItinerary> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DayTitle)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Activities)
                .IsRequired();

            builder.HasOne(x => x.Tour)
                .WithMany(t => t.Itineraries)
                .HasForeignKey(x => x.TourId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
