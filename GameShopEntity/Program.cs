using GameShopEntity.BusinessLogicalLayer.Consumers;
using GameShopEntity.BusinessLogicalLayer.Interface.Services;
using GameShopEntity.BusinessLogicalLayer.Service;
using GameShopEntity.DataAccessLayer;
using GameShopEntity.DataAccessLayer.Data;
using GameShopEntity.DataAccessLayer.Data.Repositories;
using GameShopEntity.DataAccessLayer.Interface;
using GameShopEntity.DataAccessLayer.Interface.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

builder.Services.AddDbContext<GameShopContext>(options =>
{
    string connectionString = configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});
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

        // ������������ ���������� ����
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

builder.Services.AddTransient<IGamesService, GameService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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

app.Run();
