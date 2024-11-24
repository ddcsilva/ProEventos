namespace ProEventos.API.Extensions;

public static class ServiceExtensions
{
    /// <summary>
    /// Configura os serviços necessários para a aplicação.
    /// </summary>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Adiciona os controladores
        services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                });

        // Injeção de dependência de serviços

        return services;
    }
}
