namespace PriceMonitor.Application.UseCases.ProdutosMonitorados.CreateProdutoMonitorado;

public class CreateProdutoMonitoradoRequest
{
    public string Nome { get; set; }

    public string Url { get; set; }

    public string SiteOrigem { get; set; }
}
