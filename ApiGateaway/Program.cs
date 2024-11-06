using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Multiplexer;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseUrls("http://*:80");

// Налаштування CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

// Налаштування Ocelot
builder.Services.AddOcelot(builder.Configuration);

// Налаштування Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddSingleton<IDefinedAggregator, GameAndCartAggregator>();
// Додати Swagger для Ocelot
builder.Services.AddSwaggerForOcelot(builder.Configuration);

// Додати конфігурацію Ocelot
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

var app = builder.Build();

// Використання CORS
app.UseCors("AllowAll");

// Включити Swagger для Gateway
app.UseSwaggerForOcelotUI(options =>
{
    options.PathToSwaggerGenerator = "/swagger/docs";
});

// Додати Ocelot Middleware
await app.UseOcelot();

app.Run();