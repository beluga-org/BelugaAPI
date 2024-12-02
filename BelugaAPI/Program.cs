using System.Text.Json;
using BelugaAPI.Application;
using BelugaAPI.Persistence;
using BelugaAPI.Provider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// formatterType in MVC options
builder.Services.AddMvc(options =>
{
    options.AllowEmptyInputInBodyModelBinding = true;
    foreach (var formatter in options.InputFormatters)
    {
        if (formatter.GetType() == typeof(SystemTextJsonInputFormatter))
            ((SystemTextJsonInputFormatter)formatter).SupportedMediaTypes.Add(
                Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("text/plain"));
    }
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "API Example",
        Description = "Exemplo de API com Swagger"
    });
});

builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddProviderLayer(builder.Configuration);
builder.Services.AddApplicationLayer();

var app = builder.Build();

app.UseCors(builderCors =>
    builderCors.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BelugaAPI");
    c.OAuthClientId("swagger");
    c.OAuthClientSecret("secret");

    c.OAuthScopeSeparator(" ");
    c.OAuthScopeSeparator("BelugaAPI");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();