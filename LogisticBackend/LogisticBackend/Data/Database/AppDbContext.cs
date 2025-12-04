using LogisticBackend.Data.Database.Seed;
using LogisticBackend.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LogisticBackend.Data.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<FuelTransaction> FuelTransactions { get; set; }
        public DbSet<Maintenance> Maintenances { get; set; }
        public DbSet<Trip> TripTransactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            DatabaseSeeder.Seed(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
