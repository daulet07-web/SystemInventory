using SI.Domain.Models;

namespace SI.Infrastructure.Repositories1.Interfaces
{
    public interface IClusterRepository
    {
        Task<Cluster?> GetByIdAsync(int id);
        Task<IEnumerable<Cluster>> GetAllAsync();
        Task AddAsync(Cluster cluster);
        Task UpdateAsync(Cluster cluster);
        Task DeleteAsync(Cluster cluster);
        Task<bool> ExistsAsync(int id);
        Task<int> GetNodeCountAsync(int clusterId);
        Task<IEnumerable<Node>> GetNodesByClusterIdAsync(int clusterId);
        Task SaveChangesAsync();
    }
}