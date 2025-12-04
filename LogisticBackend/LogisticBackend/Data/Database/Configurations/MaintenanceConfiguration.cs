using LogisticBackend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticBackend.Data.Database.Configurations
{
    public class MaintenanceConfiguration : IEntityTypeConfiguration<Maintenance>
    {
        public void Configure(EntityTypeBuilder<Maintenance> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Vehicle)
                .WithMany(x => x.Maintenances)
                .HasForeignKey(x => x.VehicleId);

            builder.Property(x => x.IntervalMileage)
                .IsRequired();

            builder.Property(x => x.Cost)
                .IsRequired();

            builder.Property(x => x.Date)
                .IsRequired();

            builder.Property(x => x.Mileage)
                .IsRequired();

            builder.Property(x => x.IsCompleted)
                .IsRequired();
        }
    }
}
