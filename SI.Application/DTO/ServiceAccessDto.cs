namespace SI.Application.DTO
{
    public class ServiceAccessDto
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public int NodeId { get; set; }
        public string NodeName { get; set; }
        public string AccessType { get; set; }
        public int? CredentialId { get; set; }
        public string CredentialName { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateServiceAccessDto
    {
        public int ServiceId { get; set; }
        public int NodeId { get; set; }
        public string AccessType { get; set; }
        public int? CredentialId { get; set; }
    }

    public class UpdateServiceAccessDto
    {
        public int ServiceId { get; set; }
        public int NodeId { get; set; }
        public string AccessType { get; set; }
        public int? CredentialId { get; set; }
    }
}