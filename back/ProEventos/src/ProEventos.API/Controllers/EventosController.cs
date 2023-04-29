using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain.Interfaces.Helpers;
using ProEventos.Domain.Models;
using ProEventos.Domain.Services;

namespace ProEventos.API.Controllers;

/// <summary>
/// Controller responsável pelos endpoints de Eventos
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class EventosController : MainController
{
    private readonly IEventoService _eventoService;

    public EventosController(INotificador notificador,
                             IEventoService eventoService) : base(notificador)
    {
        _eventoService = eventoService;
    }

    /// <summary>
    /// Retorna todos os eventos
    /// </summary>
    /// <returns>Lista de eventos</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Evento>>> ObterTodosEventosAsync()
    {
        try
        {
            var eventos = await _eventoService.ObterTodosEventosAsync();
            return CustomResponse(eventos);
        }
        catch (Exception ex)
        {
            NotificarErro($"Erro ao tentar obter eventos. Erro: {ex.Message}");
            return CustomResponse(null, statusCode: 500);
        }
    }

    /// <summary>
    /// Retorna um evento pelo seu Id
    /// </summary>
    /// <param name="id">Id do evento</param>
    /// <returns>Evento</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<Evento>> ObterEventoPorIdAsync(int id)
    {
        try
        {
            var evento = await _eventoService.ObterEventoPorIdAsync(id);

            if (evento == null) return NotFound("Evento não encontrado.");

            return Ok(evento);
        }
        catch (Exception ex)
        {
            NotificarErro($"Erro ao tentar obter um evento. Erro: {ex.Message}");
            return CustomResponse(null, statusCode: 500);
        }
    }

    /// <summary>
    /// Retorna um evento pelo seu tema
    /// </summary>
    /// <param name="tema">Tema do evento</param>
    /// <returns>Evento</returns>
    [HttpGet("tema/{tema}")]
    public async Task<ActionResult<Evento>> ObterEventoPorTemaAsync(string tema)
    {
        try
        {
            var evento = await _eventoService.ObterTodosEventosPorTemaAsync(tema, true);

            if (evento == null) return NotFound("Evento não encontrado.");

            return Ok(evento);
        }
        catch (Exception ex)
        {
            NotificarErro($"Erro ao tentar obter um evento. Erro: {ex.Message}");
            return CustomResponse(null, statusCode: 500);
        }
    }

    /// <summary>
    /// Adiciona um novo evento
    /// </summary>
    /// <param name="evento">Evento a ser adicionado</param>
    /// <returns>Evento</returns>
    [HttpPost]
    public async Task<ActionResult<Evento>> AdicionarEventoAsync(Evento evento)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _eventoService.AdicionarAsync(evento);

            return CustomResponse(evento);
        }
        catch (Exception ex)
        {
            NotificarErro($"Erro ao tentar adicionar evento. Erro: {ex.Message}");
            return CustomResponse(null, statusCode: 500);
        }
    }

    /// <summary>
    /// Atualiza um evento
    /// </summary>
    /// <param name="id">Id do evento</param>
    /// <param name="evento">Evento a ser atualizado</param>
    /// <returns>Evento</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<Evento>> AtualizarEventoAsync(int id, Evento evento)
    {
        try
        {
            if (id != evento.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse();
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _eventoService.AtualizarAsync(evento);

            return CustomResponse(evento);
        }
        catch (Exception ex)
        {
            NotificarErro($"Erro ao tentar atualizar evento. Erro: {ex.Message}");
            return CustomResponse(null, statusCode: 500);
        }
    }

    /// <summary>
    /// Remove um evento
    /// </summary>
    /// <param name="id">Id do evento</param>
    /// <returns>Evento</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult<Evento>> RemoverEventoAsync(int id)
    {
        try
        {
            var evento = await _eventoService.ObterEventoPorIdAsync(id);

            if (evento == null) return NotFound("Evento não encontrado.");

            await _eventoService.RemoverAsync(id);

            return CustomResponse(evento);
        }
        catch (Exception ex)
        {
            NotificarErro($"Erro ao tentar remover evento. Erro: {ex.Message}");
            return CustomResponse(null, statusCode: 500);
        }
    }
}