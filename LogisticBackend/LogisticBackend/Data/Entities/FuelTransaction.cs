namespace LogisticBackend.Data.Entities
{
    public class FuelTransaction
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public int DriverId { get; set; }
        public Driver? Driver { get; set; }
        public DateTime Date { get; set; }
        public float Liters { get; set; }
        public decimal PricePerLiter { get; set; }
        public decimal TotalCost => (decimal)Liters * PricePerLiter;
    }
}
