using LogisticBackend.Data.Enums;

namespace LogisticBackend.Data.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string InventoryNumber { get; set; } = string.Empty;
        public string LicensePlate { get; set; } = string.Empty;
        public string VIN { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
        public string FuelType { get; set; } = string.Empty;
        public decimal InitialCost { get; set; }
        public decimal CurrentBookValue { get; set; }
        public VehicleStatus Status { get; set; }
        public float Mileage { get; set; }
        public List<Expense>? Expenses { get; set; }
        public List<Trip>? Trips { get; set; }
        public List<FuelTransaction>? FuelTransactions { get; set; }
        public List<Maintenance>? Maintenances { get; set; }
    }
}
