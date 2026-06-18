using Microsoft.EntityFrameworkCore;
using SI.Domain.Models;

namespace SI.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        // DbSet для всех моделей
        public DbSet<Device> Devices { get; set; }
        public DbSet<NetworkInterface> NetworkInterfaces { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceInstance> ServiceInstances { get; set; }
        public DbSet<Credential> Credentials { get; set; }
        public DbSet<Network> Networks { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Dependency> Dependencies { get; set; }
        public DbSet<Backup> Backups { get; set; }
        public DbSet<Cluster> Clusters { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<ServiceAccess> ServiceAccesses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Device → NetworkInterface (один ко многим)
            modelBuilder.Entity<NetworkInterface>()
                .HasOne(n => n.Device)
                .WithMany()
                .HasForeignKey(n => n.DeviceId);

            // Service → ServiceInstance (один ко многим)
            modelBuilder.Entity<ServiceInstance>()
                .HasOne(si => si.Service)
                .WithMany()
                .HasForeignKey(si => si.ServiceId);

            // ServiceInstance → Device (один ко многим)
            modelBuilder.Entity<ServiceInstance>()
                .HasOne(si => si.Device)
                .WithMany()
                .HasForeignKey(si => si.DeviceId);

            // Credential → Device
            modelBuilder.Entity<Credential>()
                .HasOne(c => c.Device)
                .WithMany()
                .HasForeignKey(c => c.DeviceId);

            // Credential → Service
            modelBuilder.Entity<Credential>()
                .HasOne(c => c.Service)
                .WithMany()
                .HasForeignKey(c => c.ServiceId);

            // Dependency → SourceService
            modelBuilder.Entity<Dependency>()
                .HasOne(d => d.SourceService)
                .WithMany()
                .HasForeignKey(d => d.SourceServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Dependency → TargetService
            modelBuilder.Entity<Dependency>()
                .HasOne(d => d.TargetService)
                .WithMany()
                .HasForeignKey(d => d.TargetServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Backup → Service
            modelBuilder.Entity<Backup>()
                .HasOne(b => b.Service)
                .WithMany()
                .HasForeignKey(b => b.ServiceId);

            // Backup → Device
            modelBuilder.Entity<Backup>()
                .HasOne(b => b.Device)
                .WithMany()
                .HasForeignKey(b => b.DeviceId);

            // AuditLog → Device
            modelBuilder.Entity<AuditLog>()
                .HasOne(a => a.Device)
                .WithMany()
                .HasForeignKey(a => a.AssetId);

            // Связь: Cluster → Node (один ко многим)
            modelBuilder.Entity<Node>()
                .HasOne(n => n.Cluster)
                .WithMany()
                .HasForeignKey(n => n.ClusterId);

            // Связь: ServiceAccess → Service
            modelBuilder.Entity<ServiceAccess>()
                .HasOne(sa => sa.Service)
                .WithMany()
                .HasForeignKey(sa => sa.ServiceId);

            // Связь: ServiceAccess → Node
            modelBuilder.Entity<ServiceAccess>()
                .HasOne(sa => sa.Node)
                .WithMany()
                .HasForeignKey(sa => sa.NodeId);

            // Связь: ServiceAccess → Credential (опционально)
            modelBuilder.Entity<ServiceAccess>()
                .HasOne(sa => sa.Credential)
                .WithMany()
                .HasForeignKey(sa => sa.CredentialId);
        }
    }
}