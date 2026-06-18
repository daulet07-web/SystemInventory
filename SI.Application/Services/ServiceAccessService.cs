using SI.Application.DTO;
using SI.Application.Interfaces;
using SI.Domain.Models;
using SI.Application.Interfaces;
using SI.Infrastructure.Repositories1.Interfaces;

namespace SI.Application.Services
{
    public class ServiceAccessService : IServiceAccessService
    {
        private readonly IServiceAccessRepository _accessRepository;

        public ServiceAccessService(IServiceAccessRepository accessRepository)
        {
            _accessRepository = accessRepository;
        }

        public async Task<IEnumerable<ServiceAccessDto>> GetAllAccessesAsync()
        {
            var accesses = await _accessRepository.GetAllAsync();
            return accesses.Select(MapToDto);
        }

        public async Task<ServiceAccessDto?> GetAccessByIdAsync(int id)
        {
            var access = await _accessRepository.GetByIdWithDetailsAsync(id);
            return access == null ? null : MapToDto(access);
        }

        public async Task<IEnumerable<ServiceAccessDto>> GetAccessesByServiceIdAsync(int serviceId)
        {
            var accesses = await _accessRepository.GetByServiceIdAsync(serviceId);
            return accesses.Select(MapToDto);
        }

        public async Task<IEnumerable<ServiceAccessDto>> GetAccessesByNodeIdAsync(int nodeId)
        {
            var accesses = await _accessRepository.GetByNodeIdAsync(nodeId);
            return accesses.Select(MapToDto);
        }

        public async Task<ServiceAccessDto> CreateAccessAsync(CreateServiceAccessDto dto)
        {
            var serviceExists = await _accessRepository.ServiceExistsAsync(dto.ServiceId);
            if (!serviceExists)
                throw new ArgumentException($"Service with ID {dto.ServiceId} not found");

            var nodeExists = await _accessRepository.NodeExistsAsync(dto.NodeId);
            if (!nodeExists)
                throw new ArgumentException($"Node with ID {dto.NodeId} not found");

            if (dto.CredentialId.HasValue)
            {
                var credentialExists = await _accessRepository.CredentialExistsAsync(dto.CredentialId.Value);
                if (!credentialExists)
                    throw new ArgumentException($"Credential with ID {dto.CredentialId} not found");
            }

            var access = new ServiceAccess
            {
                ServiceId = dto.ServiceId,
                NodeId = dto.NodeId,
                AccessType = dto.AccessType,
                CredentialId = dto.CredentialId
            };

            await _accessRepository.AddAsync(access);
            await _accessRepository.SaveChangesAsync();

            var createdAccess = await _accessRepository.GetByIdWithDetailsAsync(access.Id);
            return MapToDto(createdAccess!);
        }

        public async Task<ServiceAccessDto?> UpdateAccessAsync(int id, UpdateServiceAccessDto dto)
        {
            var access = await _accessRepository.GetByIdWithDetailsAsync(id);
            if (access == null) return null;

            if (dto.ServiceId != access.ServiceId)
            {
                var serviceExists = await _accessRepository.ServiceExistsAsync(dto.ServiceId);
                if (!serviceExists)
                    throw new ArgumentException($"Service with ID {dto.ServiceId} not found");
            }

            if (dto.NodeId != access.NodeId)
            {
                var nodeExists = await _accessRepository.NodeExistsAsync(dto.NodeId);
                if (!nodeExists)
                    throw new ArgumentException($"Node with ID {dto.NodeId} not found");
            }

            if (dto.CredentialId.HasValue && dto.CredentialId != access.CredentialId)
            {
                var credentialExists = await _accessRepository.CredentialExistsAsync(dto.CredentialId.Value);
                if (!credentialExists)
                    throw new ArgumentException($"Credential with ID {dto.CredentialId} not found");
            }

            access.ServiceId = dto.ServiceId;
            access.NodeId = dto.NodeId;
            access.AccessType = dto.AccessType;
            access.CredentialId = dto.CredentialId;

            await _accessRepository.UpdateAsync(access);
            await _accessRepository.SaveChangesAsync();

            var updatedAccess = await _accessRepository.GetByIdWithDetailsAsync(id);
            return MapToDto(updatedAccess!);
        }

        public async Task<bool> DeleteAccessAsync(int id)
        {
            var access = await _accessRepository.GetByIdAsync(id);
            if (access == null) return false;

            await _accessRepository.DeleteAsync(access);
            await _accessRepository.SaveChangesAsync();
            return true;
        }

        private ServiceAccessDto MapToDto(ServiceAccess access)
        {
            return new ServiceAccessDto
            {
                Id = access.Id,
                ServiceId = access.ServiceId,
                ServiceName = access.Service?.Name,
                NodeId = access.NodeId,
                NodeName = access.Node?.Name,
                AccessType = access.AccessType,
                CredentialId = access.CredentialId,
                CredentialName = access.Credential?.Name,
                CreatedAt = access.CreatedAt
            };
        }
    }
}