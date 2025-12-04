using LogisticBackend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticBackend.Data.Database.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Trips)
                .WithOne(x => x.Vehicle)
                .HasForeignKey(x => x.VehicleId);

            builder.HasMany(x => x.Expenses)
               .WithOne(x => x.Vehicle)
               .HasForeignKey(x => x.VehicleId);

            builder.HasMany(x => x.Maintenances)
              .WithOne(x => x.Vehicle)
              .HasForeignKey(x => x.VehicleId);

            builder.HasMany(x => x.FuelTransactions)
              .WithOne(x => x.Vehicle)
              .HasForeignKey(x => x.VehicleId);

            builder.Property(x => x.Model)
                .IsRequired();

            builder.Property(x => x.Brand)
                .IsRequired();

            builder.Property(x => x.LicensePlate)
                .IsRequired();

            builder.Property(x => x.VIN)
                .IsRequired();

            builder.Property(x => x.CurrentBookValue)
                .IsRequired();

            builder.Property(x => x.InitialCost)
                .IsRequired();

            builder.Property(x => x.Mileage)
               .IsRequired();

            builder.Property(x => x.InventoryNumber)
               .IsRequired();

            builder.Property(x => x.FuelType)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.Year)
                .IsRequired();

            builder.HasIndex(x => x.VIN)
                .IsUnique();

            builder.HasIndex(x => x.LicensePlate)
                .IsUnique();

            builder.HasIndex(x => x.InventoryNumber)
                .IsUnique();
        }
    }
}
