namespace LogisticBackend.Data.Entities
{
    public class Maintenance
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public DateTime Date { get; set; }
        public int Mileage { get; set; }
        public bool IsCompleted { get; set; }
        public float? IntervalMileage { get; set; }
        public decimal Cost { get; set; }
        public string? Description { get; set; }
        public string? ServiceCompany { get; set; }
    }
}
