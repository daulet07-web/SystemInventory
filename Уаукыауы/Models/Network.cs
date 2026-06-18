namespace SI.Domain.Models
{
    public class Network
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Subnet { get; set; } = string.Empty;
        public int? Cidr { get; set; }
        public string? Gateway { get; set; }
        public int? VlanId { get; set; }
        public string? VlanName { get; set; }
        public string? IpRangeStart { get; set; }
        public string? IpRangeEnd { get; set; }
        public string? DnsServers { get; set; }
        public string? NtpServers { get; set; }
        public string? Description { get; set; }
        public bool IsCritical { get; set; } = false;
        public string? Zone { get; set; }
    }
}