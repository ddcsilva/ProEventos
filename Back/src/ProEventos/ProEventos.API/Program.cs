using ProEventos.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configura��o de servi�os
builder.Services.AddApplicationServices();
builder.Services.AddCorsPolicies();
builder.Services.AddSwaggerDocumentation();

var app = builder.Build();

// Configura��o de middlewares
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDocumentation();
}

app.UseApplicationMiddlewares();

app.MapControllers();

app.Run();
