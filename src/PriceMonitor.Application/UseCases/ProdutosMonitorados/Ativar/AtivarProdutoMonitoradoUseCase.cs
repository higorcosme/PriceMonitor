using PriceMonitor.Application.Interfaces;

namespace PriceMonitor.Application.UseCases.ProdutosMonitorados.Ativar;

public class AtivarProdutoMonitoradoUseCase
    : IAtivarProdutoMonitoradoUseCase
{
    private readonly IProdutoMonitoradoRepository _produtoMonitoradoRepository;

    public AtivarProdutoMonitoradoUseCase(
        IProdutoMonitoradoRepository produtoMonitoradoRepository)
    {
        _produtoMonitoradoRepository = produtoMonitoradoRepository;
    }

    public async Task<bool> ExecuteAsync(Guid id)
    {
        var produtoMonitorado =
            await _produtoMonitoradoRepository.GetByIdAsync(id);

        if (produtoMonitorado is null)
            return false;

        produtoMonitorado.Ativar();

        await _produtoMonitoradoRepository.SaveChangesAsync();

        return true;
    }
}
