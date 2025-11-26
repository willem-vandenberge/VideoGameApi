using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using VideoGameApi.Model.Models;
using VideoGameAPI.Repository;
using VideoGameAPI.Repository.Contracts;
using VideoGameAPI.Repository.Core;
using VideoGameAPI.Service;
using VideoGameAPI.Service.Contracts;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddOpenApi();

// dependency injection: service registreren
// aangeven dat we sql server gebruiken => package installeren
builder.Services.AddDbContext<VideoGameDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Data access objects registreren voor DI
// AddTransient: registreren van een service met een tijdelijke levensduur
builder.Services.AddTransient<IDAO<VideoGame>, VideoGameDAO>();
builder.Services.AddTransient<IDAO<Developer>, DeveloperDAO>();

// Service klassen registreren voor DI
builder.Services.AddTransient<IService<VideoGame>, VideoGameService>();
builder.Services.AddTransient<IService<Developer>, DeveloperService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Scalar depency toevoegen om documentatie overzichtelijker te maken OpenAPI/Swaggar
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
