using Microsoft.AspNetCore.Mvc;
using PriceMonitor.Application.UseCases.HistoricoPreco.GetByProdutoId;
using PriceMonitor.Application.UseCases.ProdutosMonitorados.CreateProdutoMonitorado;
using PriceMonitor.Application.UseCases.ProdutosMonitorados.Desativar;
using PriceMonitor.Application.UseCases.ProdutosMonitorados.GetAll;
using PriceMonitor.Application.UseCases.ProdutosMonitorados.GetById;

namespace PriceMonitor.Api.Controllers;

[ApiController]
[Route("api/produtos")]
public class ProdutosMonitoradosController : ControllerBase
{
    private readonly CreateProdutoMonitoradoUseCase _createUseCase;
    private readonly IGetAllProdutosMonitoradosUseCase _getAllUseCase;
    private readonly IGetProdutoMonitoradoByIdUseCase _getByIdUseCase;
    private readonly IDesativarProdutoMonitoradoUseCase _desativarUseCase;
    private readonly IGetHistoricoPrecoByProdutoIdUseCase _historicoUseCase;

    public ProdutosMonitoradosController(CreateProdutoMonitoradoUseCase createUseCase,
    IGetAllProdutosMonitoradosUseCase getAllUseCase, IGetProdutoMonitoradoByIdUseCase getByIdUseCase,
    IDesativarProdutoMonitoradoUseCase desativarUseCase, IGetHistoricoPrecoByProdutoIdUseCase historicoUseCase)
    {
        _createUseCase = createUseCase;
        _getAllUseCase = getAllUseCase;
        _getByIdUseCase = getByIdUseCase;
        _desativarUseCase = desativarUseCase;
        _historicoUseCase = historicoUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProdutoMonitoradoRequest request)
    {
        var result = await _createUseCase.ExecuteAsync(request);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getAllUseCase.ExecuteAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _getByIdUseCase.ExecuteAsync(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    [HttpPatch("{id:guid}/desativar")]
    public async Task<IActionResult> Desativar(Guid id)
    {
        var sucesso = await _desativarUseCase.ExecuteAsync(id);

        if (!sucesso)
            return NotFound();

        return NoContent();
    }

    [HttpGet("{id:guid}/historico")]
    public async Task<IActionResult> GetHistorico(Guid id)
    {
        var historico = await _historicoUseCase.ExecuteAsync(id);

        return Ok(historico);
    }
}
