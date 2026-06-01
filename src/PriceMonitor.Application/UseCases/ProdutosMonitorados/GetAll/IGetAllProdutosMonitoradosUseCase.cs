namespace PriceMonitor.Application.UseCases.ProdutosMonitorados.GetAll;

public interface IGetAllProdutosMonitoradosUseCase
{
    Task<List<GetAllProdutosMonitoradosResponse>> ExecuteAsync();
}
