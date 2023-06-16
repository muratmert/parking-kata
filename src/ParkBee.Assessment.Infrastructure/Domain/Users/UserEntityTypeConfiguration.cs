using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkBee.Asssessment.Domain.Users;

namespace ParkBee.Assessment.Infrastructure.Domain.Users
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(b => b.Id);
            builder.Property("Name").HasColumnName("Name");
            builder.Property("Password").HasColumnName("Password");
            builder.Property("Email").HasColumnName("Email");
            builder.Property("GarageId").HasColumnName("GarageId");
        }
    }
}