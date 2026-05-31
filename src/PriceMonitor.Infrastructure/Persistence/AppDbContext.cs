using Microsoft.EntityFrameworkCore;
using PriceMonitor.Domain;

namespace PriceMonitor.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<ProdutoMonitorado> ProdutosMonitorados  { get; set; }

    public DbSet<HistoricoPreco> HistoricosPreco { get; set; }
}
