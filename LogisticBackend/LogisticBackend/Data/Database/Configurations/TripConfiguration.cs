using LogisticBackend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticBackend.Data.Database.Configurations
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Vehicle)
                .WithMany(x => x.Trips)
                .HasForeignKey(x => x.VehicleId);

            builder.HasOne(x => x.Driver)
                .WithMany(x => x.Trips)
                .HasForeignKey(x => x.DriverId);

            builder.Property(x => x.Number)
                .IsRequired();

            builder.Property(x => x.StartMileage)
                .IsRequired();

            builder.Property(x => x.StartDateTime)
                .IsRequired();

            builder.Property(x => x.CargoDescription)
                .IsRequired();

            builder.Property(x => x.CargoWeight)
                .IsRequired();

            builder.Property(x => x.EndDateTime)
                .IsRequired();

            builder.Property(x => x.EndMileage)
                .IsRequired();

            builder.Property(x => x.FuelSpent)
                .IsRequired();

            builder.Property(x => x.Route)
                .IsRequired();

            builder.HasIndex(x => x.Number)
                .IsUnique();
        }
    }
}
