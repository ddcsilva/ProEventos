using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    public EventoController()
    {
    }

    public IEnumerable<Evento> eventos = new Evento[] {
        new Evento() {
            Id = 1,
            Tema = "Angular 11 e .NET 5",
            Local = "Jacareí",
            Lote = "1º Lote",
            QuantidadePessoas = 250,
            DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
        },
        new Evento() {
            Id = 2,
            Tema = "Angular 11 e Suas Novidades",
            Local = "São Paulo",
            Lote = "2º Lote",
            QuantidadePessoas = 350,
            DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
        }
    };

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return eventos;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
        return eventos.Where(evento => evento.Id == id);
    }

    [HttpPost]
    public string Post()
    {
        return "Exemplo de Post";
    }

    [HttpPut("{id}")]
    public string Put(int id)
    {
        return $"Exemplo de Put com id = {id}";
    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
        return $"Exemplo de Delete com id = {id}";
    }
}