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
    public class TourInclusionConfiguration : IEntityTypeConfiguration<TourInclusion>
    {
        public void Configure(EntityTypeBuilder<TourInclusion> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.InclusionDetails)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.HasOne(x => x.Tour)
                   .WithMany(t => t.Inclusions)
                   .HasForeignKey(x => x.TourId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
