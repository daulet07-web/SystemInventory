using Microsoft.EntityFrameworkCore;
using SI.Domain.Models;
using SI.Infrastructure.Data;
using SI.Infrastructure.Repositories1.Interfaces;

namespace SI.Infrastructure.Repositories1.Implementations
{
    public class ServiceAccessRepository : IServiceAccessRepository
    {
        private readonly AppDbContext _context;

        public ServiceAccessRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceAccess?> GetByIdAsync(int id)
        {
            return await _context.ServiceAccesses.FindAsync(id);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<ServiceAccess?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.ServiceAccesses
                .Include(sa => sa.Service)
                .Include(sa => sa.Node)
                .Include(sa => sa.Credential)
                .FirstOrDefaultAsync(sa => sa.Id == id);
        }

        public async Task<IEnumerable<ServiceAccess>> GetAllAsync()
        {
            return await _context.ServiceAccesses
                .Include(sa => sa.Service)
                .Include(sa => sa.Node)
                .Include(sa => sa.Credential)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceAccess>> GetByServiceIdAsync(int serviceId)
        {
            return await _context.ServiceAccesses
                .Where(sa => sa.ServiceId == serviceId)
                .Include(sa => sa.Node)
                .Include(sa => sa.Credential)
                .ToListAsync();
        }

        public async Task<IEnumerable<ServiceAccess>> GetByNodeIdAsync(int nodeId)
        {
            return await _context.ServiceAccesses
                .Where(sa => sa.NodeId == nodeId)
                .Include(sa => sa.Service)
                .Include(sa => sa.Credential)
                .ToListAsync();
        }

        public async Task AddAsync(ServiceAccess access)
        {
            access.CreatedAt = DateTime.UtcNow;
            await _context.ServiceAccesses.AddAsync(access);
        }

        public async Task UpdateAsync(ServiceAccess access)
        {
            _context.ServiceAccesses.Update(access);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(ServiceAccess access)
        {
            _context.ServiceAccesses.Remove(access);
            await Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.ServiceAccesses.AnyAsync(sa => sa.Id == id);
        }

        public async Task<bool> ServiceExistsAsync(int serviceId)
        {
            return await _context.Services.AnyAsync(s => s.Id == serviceId);
        }

        public async Task<bool> NodeExistsAsync(int nodeId)
        {
            return await _context.Nodes.AnyAsync(n => n.Id == nodeId);
        }

        public async Task<bool> CredentialExistsAsync(int credentialId)
        {
            return await _context.Credentials.AnyAsync(c => c.Id == credentialId);
        }
    }
}