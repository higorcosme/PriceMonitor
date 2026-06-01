using Microsoft.Extensions.DependencyInjection;
using PriceMonitor.Application.Interfaces;
using PriceMonitor.Infrastructure.Repositories;
using PriceMonitor.Infrastructure.Services;

namespace PriceMonitor.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Repositories
        services.AddScoped<IProdutoMonitoradoRepository, ProdutoMonitoradoRepository>();
        services.AddScoped<IHistoricoPrecoRepository, HistoricoPrecoRepository>();
        services.AddScoped<IEmailNotificationService, EmailNotificationService>();

        services.AddHttpClient<IPriceScraperService, PriceScraperService>();

        return services;
    }
}
