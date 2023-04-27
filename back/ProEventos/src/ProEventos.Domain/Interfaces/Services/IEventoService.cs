using ProEventos.Domain.Models;

namespace ProEventos.Domain.Services;

public interface IEventoService
{
    Task AdicionarAsync(Evento evento);
    Task AtualizarAsync(Evento evento);
    Task RemoverAsync(int id);

    Task<IEnumerable<Evento>> ObterTodosEventosAsync(bool incluirPalestrantes = false);
    Task<Evento> ObterEventoPorIdAsync(int eventoId, bool incluirPalestrantes = false);
    Task<IEnumerable<Evento>> ObterTodosEventosPorTemaAsync(string tema, bool incluirPalestrantes = false);
}