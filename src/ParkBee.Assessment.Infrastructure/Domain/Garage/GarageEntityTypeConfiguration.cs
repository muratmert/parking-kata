using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ParkBee.Assessment.Infrastructure.Domain.Garage
{
    public class GarageEntityTypeConfiguration : IEntityTypeConfiguration<Assessment.Domain.Garages.Garage>
    {
        public void Configure(EntityTypeBuilder<Assessment.Domain.Garages.Garage> builder)
        {
            builder.ToTable("Garages");
            builder.HasKey(b => b.Id);
            builder.Property<string>("Name").HasColumnName("Name");
            builder.Property<string>("Address").HasColumnName("Address");
            builder.HasMany(d => d.Doors)
                .WithOne(g => g.Garage);
        }
    }
}