using LogisticBackend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticBackend.Data.Database.Configurations
{
    public class FuelTransactionConfiguration : IEntityTypeConfiguration<FuelTransaction>
    {
        public void Configure(EntityTypeBuilder<FuelTransaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Driver)
                .WithMany(x => x.FuelTransactions)
                .HasForeignKey(x => x.DriverId);

            builder.HasOne(x => x.Vehicle)
                .WithMany(x => x.FuelTransactions)
                .HasForeignKey(x => x.VehicleId);

            builder.Property(x => x.PricePerLiter)
                .IsRequired();

            builder.Property(x => x.Liters)
                .IsRequired();

            builder.Property(x => x.Date)
                .IsRequired();

        }
    }
}
