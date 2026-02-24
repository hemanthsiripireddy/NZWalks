using NZWalks.API.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddScoped<IRegionRepository, SQLRegionRepository>();


builder.Services.AddDbContext<NZWalksDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("NZWalksConnectionString");

    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21)));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
