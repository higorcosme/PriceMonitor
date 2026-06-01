using PriceMonitor.Application.Interfaces;

namespace PriceMonitor.Application.UseCases.ProdutosMonitorados.Desativar;

public class DesativarProdutoMonitoradoUseCase
    : IDesativarProdutoMonitoradoUseCase
{
    private readonly IProdutoMonitoradoRepository _repository;

    public DesativarProdutoMonitoradoUseCase(
        IProdutoMonitoradoRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> ExecuteAsync(Guid id)
    {
        var produto = await _repository.GetByIdAsync(id);

        if (produto is null)
            return false;

        produto.Desativar();

        await _repository.SaveChangesAsync();

        return true;
    }
}
