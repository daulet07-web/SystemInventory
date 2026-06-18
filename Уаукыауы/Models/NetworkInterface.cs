namespace SI.Domain.Models
{
    public class NetworkInterface
    {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? MacAddress { get; set; }
        public string? IpAddress { get; set; }
        public string? IpAddressV6 { get; set; }
        public string? SubnetMask { get; set; }
        public int? Cidr { get; set; }
        public string? Gateway { get; set; }
        public string? DnsPrimary { get; set; }
        public string? DnsSecondary { get; set; }
        public int? VlanId { get; set; }
        public string? VlanName { get; set; }
        public int? SpeedMbps { get; set; }
        public bool IsEnabled { get; set; } = true;
        public bool IsManagement { get; set; } = false;
        public bool IsDhcp { get; set; } = false;
        public int? Mtu { get; set; }

        // Навигационное свойство
        public Device? Device { get; set; }
    }
}