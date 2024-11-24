namespace ProEventos.API.Extensions;

public static class CorsExtensions
{
    /// <summary>
    /// Configura as políticas de CORS.
    /// </summary>
    public static IServiceCollection AddCorsPolicies(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("DefaultPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });

        return services;
    }
}
