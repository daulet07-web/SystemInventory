using SI.Application.DTO;

namespace SI.Application.Interfaces
{
    public interface INodeService
    {
        Task<IEnumerable<NodeDto>> GetAllNodesAsync();
        Task<NodeDto?> GetNodeByIdAsync(int id);
        Task<NodeDto> CreateNodeAsync(CreateNodeDto dto);
        Task<NodeDto?> UpdateNodeAsync(int id, UpdateNodeDto dto);
        Task<bool> DeleteNodeAsync(int id);
        Task<IEnumerable<NodeDto>> GetNodesByClusterIdAsync(int clusterId);
    }
}