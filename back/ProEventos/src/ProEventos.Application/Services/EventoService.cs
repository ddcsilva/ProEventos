using ProEventos.Domain.Interfaces.Helpers;
using ProEventos.Domain.Interfaces.Repositories;
using ProEventos.Domain.Models;
using ProEventos.Domain.Services;
using ProEventos.Domain.Validations;

namespace ProEventos.Application.Services;

public class EventoService : BaseService, IEventoService
{
    private readonly IEventoRepository _eventoRepository;

    public EventoService(IEventoRepository eventoRepository, 
                         INotificador notificador) : base(notificador)
    {
        _eventoRepository = eventoRepository;
    }

    /// <summary>
    /// Adiciona um novo evento.
    /// </summary>
    /// <param name="evento">Evento a ser adicionado.</param>
    public async Task AdicionarAsync(Evento evento)
    {
        if (!ExecutarValidacao(new EventoValidation(), evento)) return;

        if (_eventoRepository.BuscarAsync(e => e.Tema == evento.Tema).Result.Any())
        {
            Notificar("Já existe um evento com este tema.");
            return;
        }

        await _eventoRepository.AdicionarAsync(evento);
    }

    public async Task AtualizarAsync(Evento evento)
    {
        if (!ExecutarValidacao(new EventoValidation(), evento)) return;

        if (_eventoRepository.BuscarAsync(e => e.Tema == evento.Tema && e.Id != evento.Id).Result.Any())
        {
            Notificar("Já existe um evento com este tema.");
            return;
        }

        await _eventoRepository.AtualizarAsync(evento);
    }

    public async Task RemoverAsync(int id)
    {
        if (_eventoRepository.BuscarAsync(e => e.Id == id).Result.Any())
        {
            Notificar("Não foi possível encontrar o evento.");
            return;
        }

        await _eventoRepository.RemoverAsync(id);
    }

    public async Task<IEnumerable<Evento>> ObterTodosEventosAsync(bool incluirPalestrantes = false)
    {
        return await _eventoRepository.ObterTodosEventosAsync(incluirPalestrantes);
    }

    public async Task<Evento> ObterEventoPorIdAsync(int eventoId, bool incluirPalestrantes = false)
    {
        if (_eventoRepository.BuscarAsync(e => e.Id == eventoId).Result.Any())
        {
            Notificar("Não foi possível encontrar o evento.");
            return null;
        }

        return await _eventoRepository.ObterEventoPorIdAsync(eventoId, incluirPalestrantes);
    }

    public async Task<IEnumerable<Evento>> ObterTodosEventosPorTemaAsync(string tema, bool incluirPalestrantes = false)
    {
        if (_eventoRepository.BuscarAsync(e => e.Tema == tema).Result.Any())
        {
            Notificar("Não foi possível encontrar o evento.");
            return null;
        }

        if (string.IsNullOrEmpty(tema))
        {
            Notificar("Tema não pode ser vazio.");
            return null;
        }

        return await _eventoRepository.ObterTodosEventosPorTemaAsync(tema, incluirPalestrantes);
    }
}