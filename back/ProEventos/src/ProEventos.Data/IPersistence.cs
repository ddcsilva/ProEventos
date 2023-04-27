using ProEventos.Domain.Models;

namespace ProEventos.Data;

/// <summary>
/// Interface de persistência de dados.
/// </summary>
public interface IPersistence
{
    /// <summary>
    /// Método genérico para adicionar entidades.
    /// </summary>
    /// <param name="entity">Entidade a ser adicionada.</param>
    void Adicionar<T>(T entity) where T : class;
    /// <summary>
    /// Método genérico para atualizar entidades.
    /// </summary>
    /// <param name="entity">Entidade a ser atualizada.</param>
    void Atualizar<T>(T entity) where T : class;
    /// <summary>
    /// Método genérico para excluir entidades.
    /// </summary>
    /// <param name="entity">Entidade a ser deletada.</param>
    void Excluir<T>(T entity) where T : class;
    /// <summary>
    /// Método genérico para excluir um array de entidades.
    /// </summary>
    /// <param name="entityArray">Array de entidades a serem deletadas.</param>
    void ExcluirVarios<T>(T[] entityArray) where T : class;
    /// <summary>
    /// Método para salvar as alterações no banco de dados.
    /// </summary>
    /// <returns>Retorna verdadeiro se as alterações foram salvas com sucesso.</returns>
    Task<bool> SaveChangesAsync();

    // Eventos

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

    // Palestrantes

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