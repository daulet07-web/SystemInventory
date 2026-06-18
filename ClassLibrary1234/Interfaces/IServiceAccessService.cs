using SI.Application.DTO;

namespace SI.Application.Interfaces
{
    public interface IServiceAccessService
    {
        Task<IEnumerable<ServiceAccessDto>> GetAllAccessesAsync();
        Task<ServiceAccessDto?> GetAccessByIdAsync(int id);
        Task<IEnumerable<ServiceAccessDto>> GetAccessesByServiceIdAsync(int serviceId);
        Task<IEnumerable<ServiceAccessDto>> GetAccessesByNodeIdAsync(int nodeId);
        Task<ServiceAccessDto> CreateAccessAsync(CreateServiceAccessDto dto);
        Task<ServiceAccessDto?> UpdateAccessAsync(int id, UpdateServiceAccessDto dto);
        Task<bool> DeleteAccessAsync(int id);
    }
}