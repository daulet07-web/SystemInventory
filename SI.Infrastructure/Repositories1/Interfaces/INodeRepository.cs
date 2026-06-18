using SI.Domain.Models;

namespace SI.Infrastructure.Repositories1.Interfaces
{
    public interface INodeRepository
    {
        Task<Node?> GetByIdAsync(int id);
        Task<Node?> GetByIdWithClusterAsync(int id);
        Task<IEnumerable<Node>> GetAllAsync();
        Task<IEnumerable<Node>> GetByClusterIdAsync(int clusterId);
        Task AddAsync(Node node);
        Task UpdateAsync(Node node);
        Task DeleteAsync(Node node);
        Task<bool> ExistsAsync(int id);
        Task<bool> ClusterExistsAsync(int clusterId);
        Task SaveChangesAsync();
    }
}