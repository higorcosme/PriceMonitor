namespace PriceMonitor.Application.UseCases.ProdutosMonitorados.CreateProdutoMonitorado;

public class CreateProdutoMonitoradoResponse
{
    public Guid Id { get; set; }

    public string Nome { get; set; }

    public string Url { get; set; }

    public string SiteOrigem { get; set; }
}
