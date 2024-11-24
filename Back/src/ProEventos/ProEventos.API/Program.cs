using ProEventos.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configuração de serviços
builder.Services.AddApplicationServices();
builder.Services.AddCorsPolicies();
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

// Configuração de middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseApplicationMiddlewares();

app.MapControllers();

app.Run();
