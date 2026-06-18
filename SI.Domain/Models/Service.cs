using System;

namespace SI.Domain.Models
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? DisplayName { get; set; }
        public string ServiceType { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? RepositoryUrl { get; set; }
        public string? TechnologyStack { get; set; }
        public int? Port { get; set; }
        public string? InternalUrl { get; set; }
        public string? ExternalUrl { get; set; }
        public string? HealthCheckUrl { get; set; }
        public string Status { get; set; } = "Running";
        public string? Version { get; set; }
        public string? BuildVersion { get; set; }
        public DateTime? LastDeployDate { get; set; }
        public string? DeployedBy { get; set; }
        public string? EnvironmentVariables { get; set; }
        public bool IsContainerized { get; set; } = false;
        public string? Orchestrator { get; set; }
        public string? Namespace { get; set; }
        public string? ConfigMapName { get; set; }
        public string? SecretName { get; set; }
        public string? LogPath { get; set; }
        public int? Replicas { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}