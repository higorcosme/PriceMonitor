using PriceMonitor.Application.Interfaces;

namespace PriceMonitor.Application.UseCases.ProdutosMonitorados.GetById;

public class GetProdutoMonitoradoByIdUseCase
    : IGetProdutoMonitoradoByIdUseCase
{
    private readonly IProdutoMonitoradoRepository _repository;

    public GetProdutoMonitoradoByIdUseCase(
        IProdutoMonitoradoRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetProdutoMonitoradoByIdResponse?> ExecuteAsync(Guid id)
    {
        var produto = await _repository.GetByIdAsync(id);

        if (produto is null)
            return null;

        return new GetProdutoMonitoradoByIdResponse
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Url = produto.Url,
            SiteOrigem = produto.SiteOrigem,
            Ativo = produto.Ativo
        };
    }
}
