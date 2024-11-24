using Microsoft.OpenApi.Models;

namespace ProEventos.API.Extensions;

public static class SwaggerExtensions
{
    /// <summary>
    /// Configura o Swagger para documentação da API.
    /// </summary>
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Teste API",
                Version = "v1",
                Description = "Documentação da API Teste."
            });
        });

        return services;
    }

    /// <summary>
    /// Configura o Swagger no pipeline de middlewares.
    /// </summary>
    public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Teste API v1");
        });

        return app;
    }
}
