namespace PriceMonitor.Application.Interfaces;

// Pegar o preço atual de uma URL
public interface IPriceScraperService
{
    Task<decimal> GetCurrentPriceAsync(string url);
}
