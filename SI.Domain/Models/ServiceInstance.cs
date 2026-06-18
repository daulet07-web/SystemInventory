using System;

namespace SI.Domain.Models
{
    public class ServiceInstance
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int DeviceId { get; set; }
        public string InstanceName { get; set; } = string.Empty;
        public int? Port { get; set; }
        public string Status { get; set; } = "Running";
        public int? ProcessId { get; set; }
        public int? MemoryUsageMb { get; set; }
        public double? CpuUsagePercent { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? LastSeenAt { get; set; }
        public int RestartCount { get; set; } = 0;

        // Навигационные свойства
        public Service? Service { get; set; }
        public Device? Device { get; set; }
    }
}