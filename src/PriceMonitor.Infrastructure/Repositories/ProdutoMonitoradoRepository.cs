using Microsoft.EntityFrameworkCore;
using PriceMonitor.Application.Interfaces;
using PriceMonitor.Domain;

namespace PriceMonitor.Infrastructure.Repositories;

public class ProdutoMonitoradoRepository : IProdutoMonitoradoRepository
{
    private readonly AppDbContext _context;

    public ProdutoMonitoradoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ProdutoMonitorado produto)
    {
        await _context.ProdutosMonitorados.AddAsync(produto);
    }

    public async Task<bool> ExistsByUrlAsync(string url)
    {
        return await _context.ProdutosMonitorados
            .AnyAsync(p => p.Url == url);
    }

    public async Task<ProdutoMonitorado?> GetByIdAsync(Guid id)
    {
        return await _context.ProdutosMonitorados
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<ProdutoMonitorado>> GetActiveAsync()
    {
        return await _context.ProdutosMonitorados
            .Where(p => p.Ativo)
            .ToListAsync();
    }

    public async Task<List<ProdutoMonitorado>> GetInactiveAsync()
    {
        return await _context.ProdutosMonitorados
            .Where(p => !p.Ativo)
            .ToListAsync();
    }

    public async Task<List<ProdutoMonitorado>> GetAllAsync()
    {
        return await _context.ProdutosMonitorados
            .ToListAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
