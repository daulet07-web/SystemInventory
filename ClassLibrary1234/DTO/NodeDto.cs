namespace SI.Application.DTO
{
    public class NodeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string InternalIp { get; set; }
        public string ExternalIp { get; set; }
        public int Port { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public int? ClusterId { get; set; }
        public string ClusterName { get; set; } // для отображения
        public int CpuCores { get; set; }
        public int RamGb { get; set; }
        public int DiskGb { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateNodeDto
    {
        public string Name { get; set; }
        public string InternalIp { get; set; }
        public string ExternalIp { get; set; }
        public int Port { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public int? ClusterId { get; set; }
        public int CpuCores { get; set; }
        public int RamGb { get; set; }
        public int DiskGb { get; set; }
    }

    public class UpdateNodeDto
    {
        public string Name { get; set; }
        public string InternalIp { get; set; }
        public string ExternalIp { get; set; }
        public int Port { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public int? ClusterId { get; set; }
        public int CpuCores { get; set; }
        public int RamGb { get; set; }
        public int DiskGb { get; set; }
    }
}