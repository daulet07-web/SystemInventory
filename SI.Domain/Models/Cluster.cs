namespace SI.Domain.Models
{
    public class Cluster
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Environment { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
