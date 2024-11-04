using BelugaAPI.Application;
using BelugaAPI.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

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
builder.Services.AddApplicationLayer();

var app = builder.Build();

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