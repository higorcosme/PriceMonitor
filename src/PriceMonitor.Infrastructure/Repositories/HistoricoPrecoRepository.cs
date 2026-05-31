using Microsoft.EntityFrameworkCore;
using PriceMonitor.Application.Interfaces;
using PriceMonitor.Domain;

namespace PriceMonitor.Infrastructure.Repositories;

public class HistoricoPrecoRepository : IHistoricoPrecoRepository
{
    private readonly AppDbContext _context;

    public HistoricoPrecoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(HistoricoPreco historico)
    {
        await _context.HistoricosPreco.AddAsync(historico);
    }

    public async Task<HistoricoPreco?> GetLastByProdutoIdAsync(Guid produtoId)
    {
        return await _context.HistoricosPreco
            .Where(h => h.ProdutoMonitoradoId == produtoId)
            .OrderByDescending(h => h.DataColeta)
            .FirstOrDefaultAsync();
    }

    public async Task<List<HistoricoPreco>> GetByProdutoIdAsync(Guid produtoId)
    {
        return await _context.HistoricosPreco
            .Where(h => h.ProdutoMonitoradoId == produtoId)
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
