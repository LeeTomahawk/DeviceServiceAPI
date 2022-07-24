
using Aplication.Mappings;
using AutoMapper;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebAPI.Installer;
using Microsoft.AspNetCore.Http.Json;
using System.ComponentModel;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Repositories.Middleware;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager Configuration = builder.Configuration;
builder.Services.AddDbContextSettings(Configuration);
builder.Services.AddAuthenticationSettings(Configuration);
builder.Services.AddJsonSettings();
builder.Services.AddInfasctructureServices();
builder.Services.AddInfasctructureRepositories();
builder.Services.AddInfasctructureValidators();
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
