namespace SI.Domain.Models
{
    public class Node
    {
        public int Id { get; set; }
        public int? ClusterId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string InternalIp { get; set; } = string.Empty;
        public string? ExternalIp { get; set; }
        public int Port { get; set; }
        public string Role { get; set; } = string.Empty;
        public string Status { get; set; } = "online";
        public int CpuCores { get; set; }
        public int RamGb { get; set; }
        public int DiskGb { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Cluster? Cluster { get; set; }
    }
}