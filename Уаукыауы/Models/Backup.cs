using System;

namespace SI.Domain.Models
{
    public class Backup
    {
        public int Id { get; set; }
        public int? ServiceId { get; set; }
        public int? DeviceId { get; set; }
        public string BackupType { get; set; } = string.Empty;
        public string? Schedule { get; set; }
        public int RetentionDays { get; set; } = 30;
        public string? BackupLocation { get; set; }
        public DateTime? LastBackupAt { get; set; }
        public double? LastBackupSizeGb { get; set; }
        public string BackupStatus { get; set; } = "Pending";
        public DateTime? RestoreTestedAt { get; set; }

        // Навигационные свойства
        public Service? Service { get; set; }
        public Device? Device { get; set; }
    }
}