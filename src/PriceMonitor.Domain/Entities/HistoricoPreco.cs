namespace PriceMonitor.Domain;

public class HistoricoPreco
{
    public Guid Id { get; private set; }

    public Guid ProdutoMonitoradoId { get; private set; }

    public decimal Preco { get; private set; }

    public DateTime DataColeta { get; private set; }

    private HistoricoPreco() { } // EF Core

    public HistoricoPreco(Guid produtoMonitoradoId, decimal preco)
    {
        Id = Guid.NewGuid();
        ProdutoMonitoradoId = produtoMonitoradoId;
        Preco = preco;
        DataColeta = DateTime.UtcNow;
    }
}
