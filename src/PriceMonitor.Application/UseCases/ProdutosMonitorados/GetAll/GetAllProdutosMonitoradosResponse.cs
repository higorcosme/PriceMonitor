namespace PriceMonitor.Application.UseCases.ProdutosMonitorados.GetAll;

public class GetAllProdutosMonitoradosResponse
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public bool Ativo { get; set; }
}

