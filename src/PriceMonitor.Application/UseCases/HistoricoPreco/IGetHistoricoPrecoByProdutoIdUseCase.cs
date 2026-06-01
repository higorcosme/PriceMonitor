namespace PriceMonitor.Application.UseCases.HistoricoPreco.GetByProdutoId;

public interface IGetHistoricoPrecoByProdutoIdUseCase
{
    Task<List<GetHistoricoPrecoByProdutoIdResponse>> ExecuteAsync(Guid produtoId);
}
