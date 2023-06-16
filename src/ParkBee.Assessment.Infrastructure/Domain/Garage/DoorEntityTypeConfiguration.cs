using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkBee.Assessment.Domain.Garages;

namespace ParkBee.Assessment.Infrastructure.Domain.Garage
{
    public class DoorEntityTypeConfiguration : IEntityTypeConfiguration<Door>
    {
        public void Configure(EntityTypeBuilder<Door> builder)
        {
            builder.ToTable("Doors");
            builder.HasKey(b => b.Id);
            builder.Property<string>("IpAddress").HasColumnName("IpAddress");
            builder.Property<bool>("Status").HasColumnName("Status");
            builder.HasOne(g=>g.Garage);
        }
    }

    public class DoorHistoryTypeConfiguration : IEntityTypeConfiguration<DoorHistory>
    {
        public void Configure(EntityTypeBuilder<DoorHistory> builder)
        {
            builder.ToTable("DoorHistory");
            builder.HasKey(b => b.HistoryId);
            builder.Property<int>("DoorId").HasColumnName("DoorId");
            builder.Property<bool>("Status").HasColumnName("Status");
            builder.Property<DateTime>("CreatedDateTime").HasColumnName("CreatedDateTime");
        }
    }
}