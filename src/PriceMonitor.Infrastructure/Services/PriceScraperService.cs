using System.Text.RegularExpressions;
using PriceMonitor.Application.Interfaces;

namespace PriceMonitor.Infrastructure.Services;

public class PriceScraperService : IPriceScraperService
{
    private readonly HttpClient _httpClient;

    public PriceScraperService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<decimal> GetCurrentPriceAsync(string url)
    {
        var html = await _httpClient.GetStringAsync(url);

        // ⚠️ versão simples (MVP) — depois vamos melhorar
        var price = ExtractPrice(html);

        return price;
    }

    private decimal ExtractPrice(string html)
    {
        // tenta pegar algo tipo "R$ 1.234,56"
        var match = Regex.Match(html, @"R\$\s?([\d\.\,]+)");

        if (!match.Success)
            throw new Exception("Preço não encontrado no HTML");

        var value = match.Groups[1].Value;

        // normaliza formato BR
        value = value.Replace(".", "").Replace(",", ".");

        return decimal.Parse(value);
    }
}
