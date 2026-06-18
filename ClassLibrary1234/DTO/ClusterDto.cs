namespace SI.Application.DTO
{
    public class ClusterDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Environment { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int NodeCount { get; set; } // дополнительное поле для информации
    }

    public class CreateClusterDto
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Environment { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateClusterDto
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Environment { get; set; }
        public string? Description { get; set; }
    }
}