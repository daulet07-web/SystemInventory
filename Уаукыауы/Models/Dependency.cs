namespace SI.Domain.Models
{
    public class Dependency
    {
        public int Id { get; set; }
        public int SourceServiceId { get; set; }
        public int TargetServiceId { get; set; }
        public string DependencyType { get; set; } = string.Empty;
        public bool IsCritical { get; set; } = true;

        // Навигационные свойства
        public Service? SourceService { get; set; }
        public Service? TargetService { get; set; }
    }
}