using PriceMonitor.Application.UseCases.HistoricoPreco.GetByProdutoId;
using PriceMonitor.Application.UseCases.ProdutosMonitorados.Ativar;
using PriceMonitor.Application.UseCases.ProdutosMonitorados.CreateProdutoMonitorado;
using PriceMonitor.Application.UseCases.ProdutosMonitorados.Desativar;
using PriceMonitor.Application.UseCases.ProdutosMonitorados.GetAll;
using PriceMonitor.Application.UseCases.ProdutosMonitorados.GetById;

namespace PriceMonitor.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<CreateProdutoMonitoradoUseCase>();

        services.AddScoped<IGetAllProdutosMonitoradosUseCase, GetAllProdutosMonitoradosUseCase>();

        services.AddScoped<IGetProdutoMonitoradoByIdUseCase, GetProdutoMonitoradoByIdUseCase>();

        services.AddScoped<IDesativarProdutoMonitoradoUseCase, DesativarProdutoMonitoradoUseCase>();

        services.AddScoped<IAtivarProdutoMonitoradoUseCase, AtivarProdutoMonitoradoUseCase>();

        services.AddScoped<IGetHistoricoPrecoByProdutoIdUseCase, GetHistoricoPrecoByProdutoIdUseCase>();

        services.AddScoped<CheckProdutoPrecoUseCase>();

        return services;
    }
}
