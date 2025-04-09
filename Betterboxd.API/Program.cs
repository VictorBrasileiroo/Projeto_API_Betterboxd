using Betterboxd.App.Interfaces;
using Betterboxd.App.Services;
using Betterboxd.App.Validations;
using Betterboxd.Core.Interfaces;
using Betterboxd.Infra.Context;
using Betterboxd.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IFilmeRepository, FilmeRepository>();
builder.Services.AddScoped<IFilmeServices, FilmeServices>();

#pragma warning disable CS0618 // O tipo ou membro é obsoleto
builder.Services.AddControllers()
    .AddFluentValidation(fv =>
    {
        fv.RegisterValidatorsFromAssemblyContaining<FilmeCriarValidator>();
        fv.RegisterValidatorsFromAssemblyContaining<FilmeEditarValidator>();
    });
#pragma warning restore CS0618 // O tipo ou membro é obsoleto

var app = builder.Build();

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
