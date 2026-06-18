namespace SI.Domain.Models
{
    public class ServiceAccess
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int NodeId { get; set; }
        public string AccessType { get; set; } = string.Empty;
        public int? CredentialId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public Service? Service { get; set; }
        public Node? Node { get; set; }
        public Credential? Credential { get; set; }
    }
}