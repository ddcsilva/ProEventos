using ProEventos.Domain.Models;

namespace ProEventos.Domain.Interfaces.Repositories;

/// <summary>
/// Interface para o repositório de eventos.
/// </summary>
public interface IEventoRepository : IRepository<Evento>
{
    /// <summary>
    /// Método para obter todos os eventos por tema.
    /// </summary>
    /// <param name="tema">Tema a ser pesquisado.</param>
    /// <param name="incluirPalestrantes">Flag para incluir os palestrantes.</param>
    /// <returns>Retorna um array de eventos.</returns>
    Task<Evento[]> ObterTodosEventosPorTemaAsync(string tema, bool incluirPalestrantes);

    /// <summary>
    /// Método para obter todos os eventos.
    /// </summary>
    /// <param name="incluirPalestrantes">Flag para incluir os palestrantes.</param>
    /// <returns>Retorna um array de eventos.</returns>
    Task<Evento[]> ObterTodosEventosAsync(bool incluirPalestrantes);

    /// <summary>
    /// Método para obter um evento pelo id.
    /// </summary>
    /// <param name="eventoId">Id do evento a ser pesquisado.</param>
    /// <param name="incluirPalestrantes">Flag para incluir os palestrantes.</param>
    /// <returns>Retorna um evento.</returns>
    Task<Evento> ObterEventoPorIdAsync(int eventoId, bool incluirPalestrantes);
}