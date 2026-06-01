namespace PriceMonitor.Application.UseCases.ProdutosMonitorados.Desativar;

public interface IDesativarProdutoMonitoradoUseCase
{
    Task<bool> ExecuteAsync(Guid id);
}
