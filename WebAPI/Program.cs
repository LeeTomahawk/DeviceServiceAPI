
using Aplication.Mappings;
using WebAPI.Installer;
using FluentValidation.AspNetCore;
using Repositories.Middleware;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager Configuration = builder.Configuration;
builder.Services.AddDbContextSettings(Configuration);
builder.Services.AddAuthenticationSettings(Configuration);
builder.Services.AddJsonSettings();
builder.Services.AddCustomCors(Configuration);
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

app.UseCors("AllowedHosts");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
