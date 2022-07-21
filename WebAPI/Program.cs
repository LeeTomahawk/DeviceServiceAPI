
using Aplication.Mappings;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebAPI.Installer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigurationManager Configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddControllersWithViews().AddJsonOptions(o => { var enums = new JsonStringEnumConverter(); o.JsonSerializerOptions.Converters.Add(enums); });
builder.Services.AddDbContext<DSMDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
builder.Services.AddInfasctructureServices();
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
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
