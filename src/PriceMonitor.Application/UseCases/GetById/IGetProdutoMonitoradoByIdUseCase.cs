namespace PriceMonitor.Application.UseCases.ProdutosMonitorados.GetById;

public interface IGetProdutoMonitoradoByIdUseCase
{
    Task<GetProdutoMonitoradoByIdResponse?> ExecuteAsync(Guid id);
}
