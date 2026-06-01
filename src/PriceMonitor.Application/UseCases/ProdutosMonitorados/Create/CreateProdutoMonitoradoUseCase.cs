using PriceMonitor.Application.Interfaces;
using PriceMonitor.Domain;

namespace PriceMonitor.Application.UseCases.ProdutosMonitorados.CreateProdutoMonitorado;

public class CreateProdutoMonitoradoUseCase
{
    private readonly IProdutoMonitoradoRepository _repository;

    public CreateProdutoMonitoradoUseCase(IProdutoMonitoradoRepository repository)
    {
        _repository = repository;
    }

    public async Task<CreateProdutoMonitoradoResponse> ExecuteAsync(CreateProdutoMonitoradoRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Nome))
            throw new ArgumentException("Nome é obrigatório");

        if (string.IsNullOrWhiteSpace(request.Url))
            throw new ArgumentException("URL é obrigatória");

        var exists = await _repository.ExistsByUrlAsync(request.Url);
        if (exists)
            throw new InvalidOperationException("Produto já cadastrado com essa URL");

        var produto = new ProdutoMonitorado(
            request.Nome,
            request.Url,
            request.SiteOrigem
        );

        await _repository.AddAsync(produto);
        await _repository.SaveChangesAsync();

        return new CreateProdutoMonitoradoResponse
        {
            Id = produto.Id,
            Nome = produto.Nome,
            Url = produto.Url,
            SiteOrigem = produto.SiteOrigem
        };
    }
}
