using SI.Domain.Models;

namespace SI.Infrastructure.Repositories1.Interfaces
{
    public interface IDeviceRepository
    {
        Task<Device?> GetByIdAsync(int id);
        Task<IEnumerable<Device>> GetAllAsync();
        Task AddAsync(Device device);
        Task UpdateAsync(Device device);
        Task DeleteAsync(Device device);
        Task<bool> ExistsAsync(int id);
        Task SaveChangesAsync();
    }
}