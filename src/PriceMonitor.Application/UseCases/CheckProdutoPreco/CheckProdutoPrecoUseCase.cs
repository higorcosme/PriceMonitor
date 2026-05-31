using PriceMonitor.Application.Interfaces;
using PriceMonitor.Application.UseCases.ProdutosMonitorados.CheckProdutoPreco;
using PriceMonitor.Domain;

namespace PriceMonitor.Application;

public class CheckProdutoPrecoUseCase
{
    private readonly IPriceScraperService _scraper;
    private readonly IHistoricoPrecoRepository _historicoRepository;
    private readonly IProdutoMonitoradoRepository _produtoRepository;
    private readonly IEmailNotificationService _emailService;

    public CheckProdutoPrecoUseCase(
        IPriceScraperService scraper,
        IHistoricoPrecoRepository historicoRepository,
        IProdutoMonitoradoRepository produtoRepository,
        IEmailNotificationService emailService)
    {
        _scraper = scraper;
        _historicoRepository = historicoRepository;
        _produtoRepository = produtoRepository;
        _emailService = emailService;
    }

    public async Task<CheckProdutoPrecoResponse> ExecuteAsync(CheckProdutoPrecoRequest request)
    {
        var produto = await _produtoRepository.GetByIdAsync(request.ProdutoId);

        if (produto is null)
            throw new Exception("Produto não encontrado");

        var currentPrice = await _scraper.GetCurrentPriceAsync(produto.Url);

        var last = await _historicoRepository.GetLastByProdutoIdAsync(produto.Id);

        var lastPrice = last?.Preco;

        bool changed = last == null || lastPrice != currentPrice;

        if (changed)
        {
            var historico = new HistoricoPreco(produto.Id, currentPrice);

            await _historicoRepository.AddAsync(historico);
            await _historicoRepository.SaveChangesAsync();

            if (lastPrice.HasValue)
            {
                await _emailService.SendPriceChangedAsync(
                    "seu-email@email.com",
                    produto.Nome,
                    lastPrice.Value,
                    currentPrice
                );
            }
        }

        return new CheckProdutoPrecoResponse
        {
            ProdutoId = produto.Id,
            CurrentPrice = currentPrice,
            LastPrice = lastPrice,
            PriceChanged = changed
        };
    }
}
