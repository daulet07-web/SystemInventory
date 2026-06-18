using Microsoft.EntityFrameworkCore;
using SI.Domain.Models;
using SI.Infrastructure.Data;
using SI.Infrastructure.Repositories1.Interfaces;

namespace SI.Infrastructure.Repositories1.Implementations
{
    public class NodeRepository : INodeRepository
    {
        private readonly AppDbContext _context;

        public NodeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<Node?> GetByIdAsync(int id)
        {
            return await _context.Nodes.FindAsync(id);
        }

        public async Task<Node?> GetByIdWithClusterAsync(int id)
        {
            return await _context.Nodes
                .Include(n => n.Cluster)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task<IEnumerable<Node>> GetAllAsync()
        {
            return await _context.Nodes
                .Include(n => n.Cluster)
                .ToListAsync();
        }

        public async Task<IEnumerable<Node>> GetByClusterIdAsync(int clusterId)
        {
            return await _context.Nodes
                .Where(n => n.ClusterId == clusterId)
                .ToListAsync();
        }

        public async Task AddAsync(Node node)
        {
            node.CreatedAt = DateTime.UtcNow;
            await _context.Nodes.AddAsync(node);
        }

        public async Task UpdateAsync(Node node)
        {
            _context.Nodes.Update(node);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Node node)
        {
            _context.Nodes.Remove(node);
            await Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Nodes.AnyAsync(n => n.Id == id);
        }

        public async Task<bool> IsClusterExistsAsync(int clusterId)
        {
            return await _context.Clusters.AnyAsync(c => c.Id == clusterId);
        }
        public async Task<bool> ClusterExistsAsync(int clusterId)
        {
            return await _context.Clusters.AnyAsync(c => c.Id == clusterId);
        }
    }
}