namespace PriceMonitor.Domain;

public class ProdutoMonitorado
{
    public Guid Id { get; private set; }

    public string Nome { get; private set; } = string.Empty;

    public string Url { get; private set; } = string.Empty;

    public string SiteOrigem { get; private set; } = string.Empty;

    public bool Ativo { get; private set; }

    public DateTime DataCriacao { get; private set; }

    private ProdutoMonitorado() { } // EF Core

    public ProdutoMonitorado(string nome, string url, string siteOrigem)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        Url = url;
        SiteOrigem = siteOrigem;
        Ativo = true;
        DataCriacao = DateTime.UtcNow;
    }

    public void Desativar()
    {
        Ativo = false;
    }

    public void Ativar()
    {
        Ativo = true;
    }
}
