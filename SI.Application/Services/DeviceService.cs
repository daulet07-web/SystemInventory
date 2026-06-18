using SI.Application.DTO;
using SI.Application.Interfaces;
using SI.Domain.Models;
using SI.Application.Interfaces;
using SI.Infrastructure.Repositories1.Interfaces;

namespace SI.Application.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<IEnumerable<DeviceDto>> GetAllDevicesAsync()
        {
            var devices = await _deviceRepository.GetAllAsync();
            return devices.Select(MapToDto);
        }

        public async Task<DeviceDto?> GetDeviceByIdAsync(int id)
        {
            var device = await _deviceRepository.GetByIdAsync(id);
            return device == null ? null : MapToDto(device);
        }

        public async Task<DeviceDto> CreateDeviceAsync(CreateDeviceDto dto)
        {
            var device = new Device
            {
                Name = dto.Name,
                Fqdn = dto.Fqdn,
                Type = dto.Type,
                Manufacturer = dto.Manufacturer,
                Model = dto.Model,
                SerialNumber = dto.SerialNumber,
                Status = dto.Status
            };

            await _deviceRepository.AddAsync(device);
            await _deviceRepository.SaveChangesAsync();
            return MapToDto(device);
        }

        public async Task<DeviceDto?> UpdateDeviceAsync(int id, UpdateDeviceDto dto)
        {
            var device = await _deviceRepository.GetByIdAsync(id);
            if (device == null) return null;

            device.Name = dto.Name;
            device.Fqdn = dto.Fqdn;
            device.Type = dto.Type;
            device.Manufacturer = dto.Manufacturer;
            device.Model = dto.Model;
            device.SerialNumber = dto.SerialNumber;
            device.Status = dto.Status;

            await _deviceRepository.UpdateAsync(device);
            await _deviceRepository.SaveChangesAsync();
            return MapToDto(device);
        }

        public async Task<bool> DeleteDeviceAsync(int id)
        {
            var device = await _deviceRepository.GetByIdAsync(id);
            if (device == null) return false;

            await _deviceRepository.DeleteAsync(device);
            await _deviceRepository.SaveChangesAsync();
            return true;
        }

        private DeviceDto MapToDto(Device device)
        {
            return new DeviceDto
            {
                Id = device.Id,
                Name = device.Name,
                Fqdn = device.Fqdn,
                Type = device.Type,
                Manufacturer = device.Manufacturer,
                Model = device.Model,
                SerialNumber = device.SerialNumber,
                Status = device.Status,
                CreatedAt = device.CreatedAt,
                UpdatedAt = device.UpdatedAt
            };
        }
    }
}