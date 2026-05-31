namespace PriceMonitor.Application.UseCases.ProdutosMonitorados.CheckProdutoPreco;

public class CheckProdutoPrecoResponse
{
    public Guid ProdutoId { get; set; }

    public decimal CurrentPrice { get; set; }

    public decimal? LastPrice { get; set; }

    public bool PriceChanged { get; set; }
}
