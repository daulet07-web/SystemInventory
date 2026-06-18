using SI.Application.DTO;
using SI.Application.Interfaces;
using SI.Domain.Models;
using SI.Application.Interfaces;
using SI.Infrastructure.Repositories1.Interfaces;

namespace SI.Application.Services
{
    public class ClusterService : IClusterService
    {
        private readonly IClusterRepository _clusterRepository;
        private readonly INodeRepository _nodeRepository;

        // Конструктор с DbContext
        public ClusterService(
            IClusterRepository clusterRepository,
            INodeRepository nodeRepository)
        {
            _clusterRepository = clusterRepository;
            _nodeRepository = nodeRepository;
        }

        public async Task<IEnumerable<ClusterDto>> GetAllClustersAsync()
        {
            var clusters = await _clusterRepository.GetAllAsync();
            return clusters.Select(MapToDto);
        }

        public async Task<ClusterDto?> GetClusterByIdAsync(int id)
        {
            var cluster = await _clusterRepository.GetByIdAsync(id);
            if (cluster == null)
                return null;

            var nodes = await _clusterRepository.GetNodesByClusterIdAsync(id);
            var dto = MapToDto(cluster);
            dto.NodeCount = nodes.Count();

            return dto;
        }

        public async Task<ClusterDto> CreateClusterAsync(CreateClusterDto dto)
        {
            var cluster = new Cluster
            {
                Name = dto.Name,
                Type = dto.Type,
                Environment = dto.Environment,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow
            };

            await _clusterRepository.AddAsync(cluster);
            await _clusterRepository.SaveChangesAsync();

            return MapToDto(cluster);
        }

        public async Task<ClusterDto?> UpdateClusterAsync(int id, UpdateClusterDto dto)
        {
            var cluster = await _clusterRepository.GetByIdAsync(id);
            if (cluster == null)
                return null;

            cluster.Name = dto.Name;
            cluster.Type = dto.Type;
            cluster.Environment = dto.Environment;
            cluster.Description = dto.Description;

            await _clusterRepository.UpdateAsync(cluster);
            await _clusterRepository.SaveChangesAsync();

            return MapToDto(cluster);
        }

        public async Task<bool> DeleteClusterAsync(int id)
        {
            var cluster = await _clusterRepository.GetByIdAsync(id);
            if (cluster == null)
                return false;

            // Проверяем, есть ли узлы в кластере
            var nodes = await _clusterRepository.GetNodesByClusterIdAsync(id);
            if (nodes.Any())
                throw new InvalidOperationException("Cannot delete cluster with existing nodes");

            await _clusterRepository.DeleteAsync(cluster);
            await _clusterRepository.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<NodeDto>> GetNodesByClusterIdAsync(int clusterId)
        {
            var nodes = await _nodeRepository.GetByClusterIdAsync(clusterId);
            return nodes.Select(MapToNodeDto);
        }

        // Вспомогательные методы маппинга
        private ClusterDto MapToDto(Cluster cluster)
        {
            return new ClusterDto
            {
                Id = cluster.Id,
                Name = cluster.Name,
                Type = cluster.Type,
                Environment = cluster.Environment,
                Description = cluster.Description,
                CreatedAt = cluster.CreatedAt,
                NodeCount = 0 // Будет заполнено отдельно
            };
        }

        private NodeDto MapToNodeDto(Node node)
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