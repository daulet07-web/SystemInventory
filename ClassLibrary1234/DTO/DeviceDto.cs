namespace SI.Application.DTO
{
    public class DeviceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Fqdn { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    public class CreateDeviceDto
    {
        public string Name { get; set; }
        public string Fqdn { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
    }

    public class UpdateDeviceDto
    {
        public string Name { get; set; }
        public string Fqdn { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string Status { get; set; }
    }
}