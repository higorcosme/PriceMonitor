using PriceMonitor.Application.Interfaces;

namespace PriceMonitor.Application.UseCases.ProdutosMonitorados.GetAll;

public class GetAllProdutosMonitoradosUseCase
    : IGetAllProdutosMonitoradosUseCase
{
    private readonly IProdutoMonitoradoRepository _repository;

    public GetAllProdutosMonitoradosUseCase(
        IProdutoMonitoradoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAllProdutosMonitoradosResponse>> ExecuteAsync()
    {
        var produtos = await _repository.GetAllAsync();

        return produtos.Select(p => new GetAllProdutosMonitoradosResponse
        {
            Id = p.Id,
            Nome = p.Nome,
            Url = p.Url,
            Ativo = p.Ativo
        }).ToList();
    }
}
