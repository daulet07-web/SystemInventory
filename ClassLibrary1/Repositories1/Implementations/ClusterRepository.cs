using Microsoft.EntityFrameworkCore;
using SI.Domain.Models;
using SI.Infrastructure.Data;
using SI.Infrastructure.Repositories1.Interfaces;

namespace SI.Infrastructure.Repositories1.Implementations
{
    public class ClusterRepository : IClusterRepository
    {
        private readonly AppDbContext _context;

        public ClusterRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<Cluster?> GetByIdAsync(int id)
        {
            return await _context.Clusters.FindAsync(id);
        }

        public async Task<IEnumerable<Cluster>> GetAllAsync()
        {
            return await _context.Clusters.ToListAsync();
        }

        public async Task AddAsync(Cluster cluster)
        {
            cluster.CreatedAt = DateTime.UtcNow;
            await _context.Clusters.AddAsync(cluster);
        }

        public async Task UpdateAsync(Cluster cluster)
        {
            _context.Clusters.Update(cluster);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Cluster cluster)
        {
            _context.Clusters.Remove(cluster);
            await Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Clusters.AnyAsync(c => c.Id == id);
        }

        public async Task<int> CountAsync()
        {
            return await _context.Clusters.CountAsync();
        }

        public async Task<IEnumerable<Node>> GetNodesByClusterIdAsync(int clusterId)
        {
            return await _context.Nodes
                .Where(n => n.ClusterId == clusterId)
                .ToListAsync();
        }
        public async Task<int> GetNodeCountAsync(int clusterId)
        {
            return await _context.Nodes.CountAsync(n => n.ClusterId == clusterId);
        }
        
    }
}