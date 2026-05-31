using PriceMonitor.Domain;

namespace PriceMonitor.Application.Interfaces;

public interface IProdutoMonitoradoRepository
{
    Task AddAsync(ProdutoMonitorado produto);

    Task<ProdutoMonitorado?> GetByIdAsync(Guid id);

    Task<List<ProdutoMonitorado>> GetAllAsync();

    Task<bool> ExistsByUrlAsync(string url);

    Task SaveChangesAsync();
}
