using Microsoft.EntityFrameworkCore;
using SI.Domain.Models;
using SI.Infrastructure.Data;
using SI.Infrastructure.Repositories1.Interfaces;

namespace SI.Infrastructure.Repositories1.Implementations
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext _context;

        public DeviceRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<Device?> GetByIdAsync(int id)
        {
            return await _context.Devices.FindAsync(id);
        }

        public async Task<IEnumerable<Device>> GetAllAsync()
        {
            return await _context.Devices.ToListAsync();
        }

        public async Task AddAsync(Device device)
        {
            device.CreatedAt = DateTime.UtcNow;
            device.UpdatedAt = DateTime.UtcNow;
            await _context.Devices.AddAsync(device);
        }

        public async Task UpdateAsync(Device device)
        {
            device.UpdatedAt = DateTime.UtcNow;
            _context.Devices.Update(device);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Device device)
        {
            _context.Devices.Remove(device);
            await Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Devices.AnyAsync(d => d.Id == id);
        }

    }
}