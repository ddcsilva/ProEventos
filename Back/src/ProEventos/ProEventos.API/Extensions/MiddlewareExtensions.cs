namespace ProEventos.API.Extensions;

public static class MiddlewareExtensions
{
    /// <summary>
    /// Configura os middlewares no pipeline HTTP.
    /// </summary>
    public static IApplicationBuilder UseApplicationMiddlewares(this IApplicationBuilder app)
    {
        // Redireciona para HTTPS
        app.UseHttpsRedirection();

        // Configura autorização
        app.UseAuthorization();

        // Configura CORS
        app.UseCors("DefaultPolicy");

        // Configura cabeçalhos de segurança
        app.Use(async (context, next) =>
        {
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            context.Response.Headers.Add("X-Frame-Options", "DENY");
            context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
            await next();
        });

        return app;
    }
}
