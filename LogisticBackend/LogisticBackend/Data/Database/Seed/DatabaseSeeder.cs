using LogisticBackend.Data.Entities;
using LogisticBackend.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace LogisticBackend.Data.Database.Seed
{
    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    Id = 1,
                    InventoryNumber = "INV-001",
                    LicensePlate = "1234 AB-7",
                    VIN = "VIN00000000000001",
                    Brand = "Volvo",
                    Model = "FH16",
                    Year = 2018,
                    FuelType = "Diesel",
                    InitialCost = 90000,
                    CurrentBookValue = 70000,
                    Status = VehicleStatus.Inactive,
                    Mileage = 150000
                },
                new Vehicle
                {
                    Id = 2,
                    InventoryNumber = "INV-002",
                    LicensePlate = "5678 AC-7",
                    VIN = "VIN00000000000002",
                    Brand = "Scania",
                    Model = "R500",
                    Year = 2019,
                    FuelType = "Diesel",
                    InitialCost = 105000,
                    CurrentBookValue = 85000,
                    Status = VehicleStatus.Inactive,
                    Mileage = 120000
                }
            );

            modelBuilder.Entity<Driver>().HasData(
                new Driver
                {
                    Id = 1,
                    FullName = "Иванов Иван Иванович",
                    Phone = "+375291234567",
                    ExperienceStart = new DateTime(2015, 5, 10),
                    IsActive = true
                },
                new Driver
                {
                    Id = 2,
                    FullName = "Петров Петр Петрович",
                    Phone = "+375441234567",
                    ExperienceStart = new DateTime(2018, 3, 22),
                    IsActive = true
                }
            );

            modelBuilder.Entity<Expense>().HasData(
                new Expense
                {
                    Id = 1,
                    VehicleId = 1,
                    MileageAtExpense = 150500,
                    Date = new DateTime(2024, 1, 10),
                    Amount = 350m,
                    Description = "Замена масла"
                },
                new Expense
                {
                    Id = 2,
                    VehicleId = 2,
                    MileageAtExpense = 121000,
                    Date = new DateTime(2024, 1, 15),
                    Amount = 500m,
                    Description = "Техническое обслуживание"
                }
            );

            modelBuilder.Entity<Maintenance>().HasData(
                new Maintenance
                {
                    Id = 1,
                    VehicleId = 1,
                    Date = new DateTime(2024, 2, 5),
                    Mileage = 151000,
                    IsCompleted = true,
                    IntervalMileage = 15000,
                    Cost = 800m,
                    Description = "ТО-2",
                    ServiceCompany = "ТехСервис"
                },
                new Maintenance
                {
                    Id = 2,
                    VehicleId = 2,
                    Date = new DateTime(2024, 2, 10),
                    Mileage = 121500,
                    IsCompleted = true,
                    IntervalMileage = 20000,
                    Cost = 600m,
                    Description = "ТО-1",
                    ServiceCompany = "АвтоМастер",
                }
            );

            modelBuilder.Entity<FuelTransaction>().HasData(
                new FuelTransaction
                {
                    Id = 1,
                    VehicleId = 1,
                    DriverId = 1,
                    Date = new DateTime(2024, 1, 12),
                    Liters = 150,
                    PricePerLiter = 2.1m
                },
                new FuelTransaction
                {
                    Id = 2,
                    VehicleId = 2,
                    DriverId = 2,
                    Date = new DateTime(2024, 1, 20),
                    Liters = 180,
                    PricePerLiter = 2.05m
                }
            );

            modelBuilder.Entity<Trip>().HasData(
                new Trip
                {
                    Id = 1,
                    Number = "TRIP-001",
                    VehicleId = 1,
                    DriverId = 1,
                    StartDateTime = new DateTime(2024, 1, 5, 8, 0, 0),
                    EndDateTime = new DateTime(2024, 1, 6, 18, 0, 0),
                    StartMileage = 150000,
                    EndMileage = 150450,
                    CargoDescription = "Молочная продукция",
                    CargoWeight = 5000,
                    FuelSpent = 120,
                    Route = "Минск — Брест",
                    Notes = "Без происшествий"
                },
                new Trip
                {
                    Id = 2,
                    Number = "TRIP-002",
                    VehicleId = 2,
                    DriverId = 2,
                    StartDateTime = new DateTime(2024, 1, 7, 7, 0, 0),
                    EndDateTime = new DateTime(2024, 1, 7, 22, 0, 0),
                    StartMileage = 120000,
                    EndMileage = 120380,
                    CargoDescription = "Мясная продукция",
                    CargoWeight = 3000,
                    FuelSpent = 90,
                    Route = "Минск — Гродно",
                    Notes = "",
                }
            );
        }
    }
}
