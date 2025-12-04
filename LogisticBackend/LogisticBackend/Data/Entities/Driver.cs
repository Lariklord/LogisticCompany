namespace LogisticBackend.Data.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public DateTime ExperienceStart { get; set; }
        public bool IsActive { get; set; }
        public List<Trip>? Trips { get; set; }
        public List<FuelTransaction>? FuelTransactions { get; set; }
    }
}
