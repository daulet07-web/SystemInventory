using System;

namespace SI.Domain.Models
{
    public class Credential
    {
        public int Id { get; set; }
        public int? DeviceId { get; set; }
        public int? ServiceId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string? KeyPath { get; set; }
        public int? Port { get; set; }
        public string? Protocol { get; set; }
        public string? AuthType { get; set; }
        public string? AccessLevel { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? LastUsedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public DateTime? RotateAt { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Навигационные свойства
        public Device? Device { get; set; }
        public Service? Service { get; set; }
    }
}