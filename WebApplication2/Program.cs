using Microsoft.EntityFrameworkCore;
using SI.Domain.Models;
using SI.Application.Services;
using SI.Application.Interfaces;
using SI.Infrastructure.Data;
using SI.Infrastructure.Repositories1.Interfaces;
using SI.Infrastructure.Repositories1.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// –Â„ËÒÚ‡ˆËˇ DbContext (PostgreSQL)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("Host=localhost; Database=QuoteDb; Username=postgres; Password=daulet07"));

// ===== –≈√»—“–¿÷»ﬂ –≈œŒ«»“Œ–»≈¬ =====
builder.Services.AddScoped<IClusterRepository, ClusterRepository>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<INodeRepository, NodeRepository>();
builder.Services.AddScoped<IServiceAccessRepository, ServiceAccessRepository>();

// ===== –≈√»—“–¿÷»ﬂ —≈–¬»—Œ¬ =====
builder.Services.AddScoped<IClusterService, ClusterService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<INodeService, NodeService>();
builder.Services.AddScoped<IServiceAccessService, ServiceAccessService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();