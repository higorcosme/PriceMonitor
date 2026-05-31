namespace PriceMonitor.Application.Interfaces;

// Enviar notificação quando o preço mudar
public interface IEmailNotificationService
{
    Task SendPriceChangedAsync(
        string to,
        string productName,
        decimal oldPrice,
        decimal newPrice);
}
