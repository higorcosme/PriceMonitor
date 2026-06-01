namespace PriceMonitor.Application.UseCases.ProdutosMonitorados.GetById;

public class GetProdutoMonitoradoByIdResponse
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public string SiteOrigem { get; set; } = string.Empty;

    public bool Ativo { get; set; }
}

