using Microsoft.EntityFrameworkCore;
using ParkBee.Assessment.Domain.Garages;
using ParkBee.Asssessment.Domain.Users;

namespace ParkBee.Assessment.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Garage> Garages { get; set; }

        public DbSet<DoorHistory> History { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}