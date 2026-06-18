using SI.Application.DTO;

namespace SI.Application.Interfaces
{
    public interface IDeviceService
    {
        Task<IEnumerable<DeviceDto>> GetAllDevicesAsync();
        Task<DeviceDto?> GetDeviceByIdAsync(int id);
        Task<DeviceDto> CreateDeviceAsync(CreateDeviceDto dto);
        Task<DeviceDto?> UpdateDeviceAsync(int id, UpdateDeviceDto dto);
        Task<bool> DeleteDeviceAsync(int id);
    }
}