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
    public class TourDestinationConfiguration : IEntityTypeConfiguration<TourDestination>
    {
        public void Configure(EntityTypeBuilder<TourDestination> builder)
        {
            // Primary Key (Composite Key)
            builder.HasKey(td => new { td.TourId, td.DestinationId });

            // Relation with Tour
            builder.HasOne(td => td.Tour)
                   .WithMany(t => t.TourDestinations)
                   .HasForeignKey(td => td.TourId);

            // Relation with Destination
            builder.HasOne(td => td.Destination)
                   .WithMany(d => d.TourDestinations)
                   .HasForeignKey(td => td.DestinationId);
        }
    }
}
