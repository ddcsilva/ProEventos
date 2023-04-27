using Microsoft.EntityFrameworkCore;
using ProEventos.Data.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Adicionando o contexto do banco de dados
builder.Services.AddDbContext<ProEventosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona o supporte a controllers
builder.Services.AddControllers();
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
