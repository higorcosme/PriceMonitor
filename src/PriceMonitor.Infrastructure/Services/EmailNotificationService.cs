using PriceMonitor.Application.Interfaces;

namespace PriceMonitor.Infrastructure.Services;

public class EmailNotificationService : IEmailNotificationService
{
    public async Task SendPriceChangedAsync(
        string to,
        string productName,
        decimal oldPrice,
        decimal newPrice)
    {
        // MVP (fase 1)
        Console.WriteLine("=== EMAIL ENVIADO ===");
        Console.WriteLine($"Para: {to}");
        Console.WriteLine($"Produto: {productName}");
        Console.WriteLine($"Preço antigo: {oldPrice}");
        Console.WriteLine($"Preço novo: {newPrice}");

        await Task.CompletedTask;
    }
}

