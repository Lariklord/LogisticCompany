using LogisticBackend.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LogisticBackend.Data.Database.Configurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Trips)
                .WithOne(x => x.Driver)
                .HasForeignKey(x => x.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.FuelTransactions)
                .WithOne(x => x.Driver)
                .HasForeignKey(x => x.DriverId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.Property(x => x.FullName)
                .IsRequired()
                .HasMaxLength(40);

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasIndex(x => x.FullName)
                .IsUnique();

            builder.HasIndex(x => x.Phone)
                .IsUnique();
        }
    }
}
