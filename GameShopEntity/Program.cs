using GameShopEntity.BusinessLogicalLayer.Consumers;
using GameShopEntity.BusinessLogicalLayer.Interface.Services;
using GameShopEntity.BusinessLogicalLayer.Service;
using GameShopEntity.DataAccessLayer;
using GameShopEntity.DataAccessLayer.Data;
using GameShopEntity.DataAccessLayer.Data.Repositories;
using GameShopEntity.DataAccessLayer.Interface;
using GameShopEntity.DataAccessLayer.Interface.Repositories;
using GameShopEntity.Grpc;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using BusinessGameService = GameShopEntity.BusinessLogicalLayer.Service.GameService;
using Microsoft.OpenApi.Models;
using GameShopEntity.Grpc;
using GrpcGameService = GameShopEntity.Grpc.GameService;
using GameShopEntity.gRPC;
using GameShopEntityCategory.Grpc;
using GameShopEntityAggregator.Grpc;
using Microsoft.Extensions.Options;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

builder.Services.AddDbContext<GameShopContext>(options =>
{
    string connectionString = configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

builder.Services.AddGrpc();

builder.Services.AddSingleton<GameGrpcClientService>();
builder.Services.AddGrpcClient<AggregatorService.AggregatorServiceClient>(options =>
{
    options.Address = new Uri("http://localhost:5155"); 
})
    .ConfigureHttpClient(client =>
    {
        client.DefaultRequestVersion = HttpVersion.Version11;  // Force HTTP/1.1
    });

// Зареєструйте AggregatorGrpcClientService
builder.Services.AddScoped<AggregatorGrpcClientService>();


builder.Services.AddMemoryCache();
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration["Redis:RedisConnection"];
});

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<GameCreatedEventConsumer>(); 

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq://localhost", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ExchangeType = RabbitMQ.Client.ExchangeType.Fanout; 

        cfg.ConfigurePublish(p => p.UseConcurrencyLimit(1));

        cfg.ReceiveEndpoint("game-created-queue", e =>
        {
            e.ConfigureConsumer<GameCreatedEventConsumer>(context);
            e.Bind("game-events", x => x.RoutingKey = "game.created"); 
        });

    });
});

builder.Services.AddMassTransitHostedService();

builder.Services.AddTransient<IGameRepository, GameRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IGamesService, BusinessGameService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<AggregatorGrpcClientService>();

builder.Services.AddGrpcClient<GrpcGameService.GameServiceClient>(o =>
{
    o.Address = new Uri("http://localhost:5155");
   
})
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        MaxConnectionsPerServer = 10,
        UseCookies = false
    })
    .ConfigureHttpClient(client =>
    {
        client.DefaultRequestVersion = HttpVersion.Version11;  // Force HTTP/1.1
    });

builder.Services.AddGrpcClient<CategoryService.CategoryServiceClient>(o =>
{
    o.Address = new Uri("http://localhost:5155");
    
})
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        MaxConnectionsPerServer = 10,
        UseCookies = false
    })
    .ConfigureHttpClient(client =>
    {
        client.DefaultRequestVersion = HttpVersion.Version11;  // Force HTTP/1.1
    }); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "GameShopSystem.WebAPI",
        Version = "v1"
    });
});


/*builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5155, o => o.Protocols =
        Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http1);
    options.ListenAnyIP(5155, o => o.Protocols =
        Microsoft.AspNetCore.Server.Kestrel.Core.HttpProtocols.Http2);
});*/

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GameShopSystem.WebAPI v1"));
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGrpcService<AggregatorGrpcClientService>();
app.MapGet("/aggregator", () => "This is a gRPC aggregator server.");
app.MapGrpcService<GameServiceImpl>();
app.MapGet("/", () => "This is a gRPC server.");

app.Run();
