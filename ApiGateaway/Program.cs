using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Multiplexer;

var builder = WebApplication.CreateBuilder(args);

//builder.WebHost.UseUrls("http://*:80");

// ������������ CORS
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

// ������������ Ocelot
builder.Services.AddOcelot(builder.Configuration);

// ������������ Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddSingleton<IDefinedAggregator, GameAndCartAggregator>();
// ������ Swagger ��� Ocelot
builder.Services.AddSwaggerForOcelot(builder.Configuration);

// ������ ������������ Ocelot
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

var app = builder.Build();

// ������������ CORS
app.UseCors("AllowAll");

// �������� Swagger ��� Gateway
app.UseSwaggerForOcelotUI(options =>
{
    options.PathToSwaggerGenerator = "/swagger/docs";
});

// ������ Ocelot Middleware
await app.UseOcelot();

app.Run();