using System;

namespace SI.Domain.Models
{
    public class AuditLog
    {
        public int Id { get; set; }
        public int AssetId { get; set; }
        public string Action { get; set; } = string.Empty;      // Create, Update, Delete
        public string FieldName { get; set; } = string.Empty;    // Какое поле изменилось
        public string OldValue { get; set; } = string.Empty;
        public string NewValue { get; set; } = string.Empty;
        public string ChangedBy { get; set; } = string.Empty;    // Кто изменил (имя)
        public int? ChangedByUserId { get; set; }                // Ссылка на User (если будет)
        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
        public string? IpAddress { get; set; }                   // IP запроса
        public string? UserAgent { get; set; }                   // Откуда запрос

        // Навигационные свойства
        public Device? Device { get; set; }                      // Связь с Device (вместо InventoryItem)
    }
}