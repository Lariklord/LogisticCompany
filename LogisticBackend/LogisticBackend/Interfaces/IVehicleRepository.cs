using LogisticBackend.Data.Entities;

namespace LogisticBackend.Interfaces
{
    public interface IVehicleRepository
    {
        Task<int> AddAsync(Vehicle vehicle);
        Task<List<Vehicle>> GetAllAsync();
        Task<Vehicle?> GetByIdAsync(int id);

        Task<Vehicle?> GetByNameAsync(string name);
    }
}
