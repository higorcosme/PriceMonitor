var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddInfrastructure();

builder.Services.AddApplication();

builder.Services.AddScoped<CheckProdutoPrecoUseCase>();

builder.Services.AddHostedService<Worker>();

var host = builder.Build();

host.Run();
