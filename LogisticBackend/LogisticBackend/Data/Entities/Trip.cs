using LogisticBackend.Data.Enums;

namespace LogisticBackend.Data.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public int DriverId { get; set; }
        public Driver? Driver { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int? StartMileage { get; set; }
        public int? EndMileage { get; set; }
        public string CargoDescription { get; set; } = string.Empty;
        public float CargoWeight { get; set; }
        public float? FuelSpent { get; set; }     
        public string Route { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public TripStatus Status { get; set; }
    }
}
