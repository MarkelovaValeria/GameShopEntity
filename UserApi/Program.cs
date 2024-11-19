using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using UserApi.BusinessLogicalLayer.Interface.Services;
using UserApi.BusinessLogicalLayer.Service;
using UserApi.DataAccessLayer;
using UserApi.DataAccessLayer.Data;
using UserApi.DataAccessLayer.Data.Repositories;
using UserApi.DataAccessLayer.Interface;
using UserApi.DataAccessLayer.Interface.Repositories;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDbContext<UserContext>(options =>
{
    string connectionString = configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "UserApi.WebAPI",
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
