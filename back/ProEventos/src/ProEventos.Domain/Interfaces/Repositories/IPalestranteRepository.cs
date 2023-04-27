using ProEventos.Domain.Models;

namespace ProEventos.Domain.Interfaces.Repositories;

/// <summary>
/// Interface para o repositório de palestrantes.
/// </summary>
public interface IPalestranteRepository : IRepository<Palestrante>
{
    /// <summary>
    /// Método para obter todos os palestrantes.
    /// </summary>
    /// <param name="incluirEventos">Flag para incluir os eventos.</param>
    /// <returns>Retorna um array de palestrantes.</returns>
    Task<Palestrante[]> ObterTodosPalestrantesAsync(bool incluirEventos);

    /// <summary>
    /// Método para obter todos os palestrantes por nome.
    /// </summary>
    /// <param name="nome">Nome a ser pesquisado.</param>
    /// <param name="incluirEventos">Flag para incluir os eventos.</param>
    /// <returns>Retorna um array de palestrantes.</returns>
    Task<Palestrante[]> ObterTodosPalestrantesPorNomeAsync(string nome, bool incluirEventos);

    /// <summary>
    /// Método para obter um palestrante pelo id.
    /// </summary>
    /// <param name="palestranteId">Id do palestrante a ser pesquisado.</param>
    /// <param name="incluirEventos">Flag para incluir os eventos.</param>
    /// <returns>Retorna um palestrante.</returns>
    Task<Palestrante> ObterPalestrantePorIdAsync(int palestranteId, bool incluirEventos);


}