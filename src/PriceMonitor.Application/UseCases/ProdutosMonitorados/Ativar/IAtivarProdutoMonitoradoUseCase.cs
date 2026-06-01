namespace PriceMonitor.Application.UseCases.ProdutosMonitorados.Ativar;

public interface IAtivarProdutoMonitoradoUseCase
{
    Task<bool> ExecuteAsync(Guid id);
}
