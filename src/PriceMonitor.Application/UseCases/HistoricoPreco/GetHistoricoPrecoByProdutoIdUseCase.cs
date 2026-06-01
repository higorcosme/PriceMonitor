using PriceMonitor.Application.Interfaces;

namespace PriceMonitor.Application.UseCases.HistoricoPreco.GetByProdutoId;

public class GetHistoricoPrecoByProdutoIdUseCase
    : IGetHistoricoPrecoByProdutoIdUseCase
{
    private readonly IHistoricoPrecoRepository _historicoRepository;

    public GetHistoricoPrecoByProdutoIdUseCase(
        IHistoricoPrecoRepository historicoRepository)
    {
        _historicoRepository = historicoRepository;
    }

    public async Task<List<GetHistoricoPrecoByProdutoIdResponse>> ExecuteAsync(
        Guid produtoId)
    {
        var historicos =
            await _historicoRepository.GetByProdutoIdAsync(produtoId);

        return historicos
            .Select(h => new GetHistoricoPrecoByProdutoIdResponse
            {
                Preco = h.Preco,
                DataColeta = h.DataColeta
            })
            .ToList();
    }
}
