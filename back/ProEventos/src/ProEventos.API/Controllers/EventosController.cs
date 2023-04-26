using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;
using ProEventos.Data;

namespace ProEventos.API.Controllers;

/// <summary>
/// Controller responsável pelos endpoints de Eventos
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private readonly DataContext _context;

    public EventosController(DataContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retorna todos os eventos
    /// </summary>
    /// <returns>Lista de eventos</returns>
    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _context.Eventos;
    }

    /// <summary>
    /// Retorna um evento por id
    /// </summary>
    /// <param name="id">Id do evento</param>
    /// <returns>Evento</returns>
    [HttpGet("{id}")]
    public Evento GetById(int id)
    {
        return _context.Eventos.FirstOrDefault(evento => evento.Id == id);
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