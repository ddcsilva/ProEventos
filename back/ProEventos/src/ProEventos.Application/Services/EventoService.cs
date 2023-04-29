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

        var eventosComMesmoTema = await _eventoRepository.BuscarAsync(e => e.Tema == evento.Tema);

        if (eventosComMesmoTema.Any())
        {
            Notificar("Já existe um evento com este tema.");
            return;
        }

        await _eventoRepository.AdicionarAsync(evento);
    }

    public async Task AtualizarAsync(Evento evento)
    {
        if (!ExecutarValidacao(new EventoValidation(), evento)) return;

        var eventosComMesmoTema = await _eventoRepository.BuscarAsync(e => e.Tema == evento.Tema && e.Id != evento.Id);

        if (eventosComMesmoTema.Any())
        {
            Notificar("Já existe um evento com este tema.");
            return;
        }

        var eventoAtual = await _eventoRepository.ObterEventoPorIdAsync(evento.Id, false);

        if (eventoAtual == null)
        {
            Notificar("Não foi possível encontrar o evento.");
            return;
        }

        eventoAtual.Tema = evento.Tema;
        eventoAtual.Local = evento.Local;
        eventoAtual.DataEvento = evento.DataEvento;
        eventoAtual.QuantidadePessoas = evento.QuantidadePessoas;
        eventoAtual.ImagemURL = evento.ImagemURL;
        eventoAtual.Telefone = evento.Telefone;
        eventoAtual.Email = evento.Email;
        eventoAtual.Lotes = evento.Lotes;
        eventoAtual.RedesSociais = evento.RedesSociais;
        eventoAtual.PalestrantesEventos = evento.PalestrantesEventos;

        await _eventoRepository.AtualizarAsync(eventoAtual);
    }

    public async Task RemoverAsync(int id)
    {
        var evento = await _eventoRepository.ObterEventoPorIdAsync(id, false);

        if (evento == null)
        {
            Notificar("Não foi possível encontrar o evento.");
            return;
        }

        await _eventoRepository.RemoverAsync(id);
    }

    public async Task<IEnumerable<Evento>> ObterTodosEventosAsync(bool incluirPalestrantes = false)
    {
        var eventos = await _eventoRepository.ObterTodosEventosAsync(incluirPalestrantes);

        if (eventos == null)
        {
            Notificar("Não foi possível encontrar o evento.");
            return null;
        }

        return eventos;
    }

    public async Task<Evento> ObterEventoPorIdAsync(int id, bool incluirPalestrantes = false)
    {
        var evento = await _eventoRepository.ObterEventoPorIdAsync(id, incluirPalestrantes);

        if (evento == null)
        {
            Notificar("Não foi possível encontrar o evento.");
            return null;
        }

        return evento;
    }

    public async Task<IEnumerable<Evento>> ObterTodosEventosPorTemaAsync(string tema, bool incluirPalestrantes = false)
    {
        var eventos = await _eventoRepository.ObterTodosEventosPorTemaAsync(tema, incluirPalestrantes);

        if (eventos == null)
        {
            Notificar("Não foi possível encontrar o evento.");
            return null;
        }

        if (string.IsNullOrEmpty(tema))
        {
            Notificar("Tema não pode ser vazio.");
            return null;
        }

        return eventos;
    }
}