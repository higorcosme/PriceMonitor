using Microsoft.EntityFrameworkCore;
using PriceMonitor.Infrastructure;
using PriceMonitor.Infrastructure.Services;
using PriceMonitor.Application.Interfaces;
using PriceMonitor.Application.UseCases.ProdutosMonitorados.CreateProdutoMonitorado;
using PriceMonitor.Application.UseCases.ProdutosMonitorados.GetAll;
using PriceMonitor.Application;
using PriceMonitor.Application.UseCases.ProdutosMonitorados.GetById;
using PriceMonitor.Application.UseCases.ProdutosMonitorados.Desativar;
using PriceMonitor.Application.UseCases.ProdutosMonitorados.Ativar;
using PriceMonitor.Application.UseCases.HistoricoPreco.GetByProdutoId;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddInfrastructure();

builder.Services.AddHttpClient<IPriceScraperService, PriceScraperService>();

builder.Services.AddScoped<CreateProdutoMonitoradoUseCase>();
builder.Services.AddScoped<IGetAllProdutosMonitoradosUseCase, GetAllProdutosMonitoradosUseCase>();
builder.Services.AddScoped<IGetProdutoMonitoradoByIdUseCase, GetProdutoMonitoradoByIdUseCase>();
builder.Services.AddScoped<IDesativarProdutoMonitoradoUseCase, DesativarProdutoMonitoradoUseCase>();
builder.Services.AddScoped<IAtivarProdutoMonitoradoUseCase, AtivarProdutoMonitoradoUseCase>();
builder.Services.AddScoped<IGetHistoricoPrecoByProdutoIdUseCase, GetHistoricoPrecoByProdutoIdUseCase>();
builder.Services.AddScoped<CheckProdutoPrecoUseCase>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
