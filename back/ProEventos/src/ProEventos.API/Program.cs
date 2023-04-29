using Microsoft.EntityFrameworkCore;
using ProEventos.Application.Services;
using ProEventos.Data.Contexts;
using ProEventos.Data.Repositories;
using ProEventos.Domain.Helpers;
using ProEventos.Domain.Interfaces.Helpers;
using ProEventos.Domain.Interfaces.Repositories;
using ProEventos.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionando o contexto do banco de dados
builder.Services.AddDbContext<ProEventosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona o supporte a controllers
builder.Services.AddControllers()
    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddScoped<INotificador, Notificador>();
builder.Services.AddScoped<IEventoService, EventoService>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();


// Adiciona o suporte ao CORS
builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
// Adiciona o suporte ao Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Configuração do CORS
app.UseCors(x => x.AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin());

app.MapControllers();

app.Run();
