

using SI.Domain.Models;

namespace SI.Infrastructure.Repositories1.Interfaces
{
    public interface IServiceAccessRepository
    {
        Task<ServiceAccess?> GetByIdAsync(int id);
        Task<ServiceAccess?> GetByIdWithDetailsAsync(int id);
        Task<IEnumerable<ServiceAccess>> GetAllAsync();
        Task<IEnumerable<ServiceAccess>> GetByServiceIdAsync(int serviceId);
        Task<IEnumerable<ServiceAccess>> GetByNodeIdAsync(int nodeId);
        Task AddAsync(ServiceAccess access);
        Task UpdateAsync(ServiceAccess access);
        Task DeleteAsync(ServiceAccess access);
        Task<bool> ExistsAsync(int id);
        Task<bool> ServiceExistsAsync(int serviceId);
        Task<bool> NodeExistsAsync(int nodeId);
        Task<bool> CredentialExistsAsync(int credentialId);
        Task SaveChangesAsync();
    }
}