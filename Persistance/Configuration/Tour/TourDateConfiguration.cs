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
    public class TourDateConfiguration : IEntityTypeConfiguration<TourDate>
    {
        public void Configure(EntityTypeBuilder<TourDate> builder)
        {
            builder.Property(t => t.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(t => t.StartDate)
                   .IsRequired();

            builder.Property(t => t.AvailableSeats)
                   .IsRequired();
        }
    }
}
