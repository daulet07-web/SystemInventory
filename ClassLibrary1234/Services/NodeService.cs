using SI.Application.DTO;
using SI.Application.Interfaces;
using SI.Domain.Models;
using SI.Application.Interfaces;
using SI.Infrastructure.Repositories1.Interfaces;

namespace SI.Application.Services
{
    public class NodeService : INodeService
    {
        private readonly INodeRepository _nodeRepository;

        public NodeService(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }

        public async Task<IEnumerable<NodeDto>> GetAllNodesAsync()
        {
            var nodes = await _nodeRepository.GetAllAsync();
            return nodes.Select(MapToDto);
        }

        public async Task<NodeDto?> GetNodeByIdAsync(int id)
        {
            var node = await _nodeRepository.GetByIdWithClusterAsync(id);
            return node == null ? null : MapToDto(node);
        }

        public async Task<NodeDto> CreateNodeAsync(CreateNodeDto dto)
        {
            if (dto.ClusterId.HasValue)
            {
                var clusterExists = await _nodeRepository.ClusterExistsAsync(dto.ClusterId.Value);
                if (!clusterExists)
                    throw new ArgumentException($"Cluster with ID {dto.ClusterId} not found");
            }

            var node = new Node
            {
                Name = dto.Name,
                InternalIp = dto.InternalIp,
                ExternalIp = dto.ExternalIp,
                Port = dto.Port,
                Role = dto.Role,
                Status = dto.Status,
                ClusterId = dto.ClusterId ?? 0,
                CpuCores = dto.CpuCores,
                RamGb = dto.RamGb,
                DiskGb = dto.DiskGb
            };

            await _nodeRepository.AddAsync(node);
            await _nodeRepository.SaveChangesAsync();

            var createdNode = await _nodeRepository.GetByIdWithClusterAsync(node.Id);
            return MapToDto(createdNode!);
        }

        public async Task<NodeDto?> UpdateNodeAsync(int id, UpdateNodeDto dto)
        {
            var node = await _nodeRepository.GetByIdWithClusterAsync(id);
            if (node == null) return null;

            if (dto.ClusterId.HasValue && dto.ClusterId != node.ClusterId)
            {
                var clusterExists = await _nodeRepository.ClusterExistsAsync(dto.ClusterId.Value);
                if (!clusterExists)
                    throw new ArgumentException($"Cluster with ID {dto.ClusterId} not found");
            }

            node.Name = dto.Name;
            node.InternalIp = dto.InternalIp;
            node.ExternalIp = dto.ExternalIp;
            node.Port = dto.Port;
            node.Role = dto.Role;
            node.Status = dto.Status;
            node.ClusterId = dto.ClusterId ?? 0;
            node.CpuCores = dto.CpuCores;
            node.RamGb = dto.RamGb;
            node.DiskGb = dto.DiskGb;

            await _nodeRepository.UpdateAsync(node);
            await _nodeRepository.SaveChangesAsync();

            var updatedNode = await _nodeRepository.GetByIdWithClusterAsync(id);
            return MapToDto(updatedNode!);
        }

        public async Task<bool> DeleteNodeAsync(int id)
        {
            var node = await _nodeRepository.GetByIdAsync(id);
            if (node == null) return false;

            await _nodeRepository.DeleteAsync(node);
            await _nodeRepository.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<NodeDto>> GetNodesByClusterIdAsync(int clusterId)
        {
            var nodes = await _nodeRepository.GetByClusterIdAsync(clusterId);
            return nodes.Select(MapToDto);
        }

        private NodeDto MapToDto(Node node)
        {
            return new NodeDto
            {
                Id = node.Id,
                Name = node.Name,
                InternalIp = node.InternalIp,
                ExternalIp = node.ExternalIp,
                Port = node.Port,
                Role = node.Role,
                Status = node.Status,
                ClusterId = node.ClusterId,
                ClusterName = node.Cluster?.Name,
                CpuCores = node.CpuCores,
                RamGb = node.RamGb,
                DiskGb = node.DiskGb,
                CreatedAt = node.CreatedAt
            };
        }
    }
}