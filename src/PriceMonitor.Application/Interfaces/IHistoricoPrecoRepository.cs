using PriceMonitor.Domain;

namespace PriceMonitor.Application.Interfaces;

// Armazenar e consultar histórico de preços
public interface IHistoricoPrecoRepository
{
    Task AddAsync(HistoricoPreco historico);

    Task<HistoricoPreco?> GetLastByProdutoIdAsync(Guid produtoId);

    Task<List<HistoricoPreco>> GetByProdutoIdAsync(Guid produtoId);

    Task SaveChangesAsync();
}
