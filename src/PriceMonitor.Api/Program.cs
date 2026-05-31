using Microsoft.EntityFrameworkCore;
using PriceMonitor.Infrastructure;
using PriceMonitor.Infrastructure.Services;
using PriceMonitor.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddInfrastructure();
builder.Services.AddHttpClient<IPriceScraperService, PriceScraperService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
