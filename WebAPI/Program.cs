
using Aplication.Mappings;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using WebAPI.Installer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
ConfigurationManager Configuration = builder.Configuration;
builder.Services.AddDbContext<DSMDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
builder.Services.AddInfasctructureServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
