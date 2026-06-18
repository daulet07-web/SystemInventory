using SI.Application.DTO;

namespace SI.Application.Interfaces
{
    public interface IClusterService
    {
        Task<IEnumerable<ClusterDto>> GetAllClustersAsync();
        Task<ClusterDto?> GetClusterByIdAsync(int id);
        Task<ClusterDto> CreateClusterAsync(CreateClusterDto dto);
        Task<ClusterDto?> UpdateClusterAsync(int id, UpdateClusterDto dto);
        Task<bool> DeleteClusterAsync(int id);
        Task<IEnumerable<NodeDto>> GetNodesByClusterIdAsync(int clusterId);
    }
}