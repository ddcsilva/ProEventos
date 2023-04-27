using ProEventos.Domain.Models;

namespace ProEventos.Domain.Interfaces.Repositories;

/// <summary>
/// Interface genérica para os repositórios.
/// </summary>
public interface IRepository<TEntity> : IDisposable where TEntity : BaseEntity
{
    /// <summary>
    /// Método genérico para adicionar entidades.
    /// </summary>
    /// <param name="entity">Entidade a ser adicionada.</param>
    Task AdicionarAsync(TEntity entity);

    /// <summary>
    /// Método genérico para atualizar entidades.
    /// </summary>
    /// <param name="entity">Entidade a ser atualizada.</param>
    Task AtualizarAsync(TEntity entity);
    
    /// <summary>
    /// Método genérico para excluir entidades.
    /// </summary>
    /// <param name="entity">Entidade a ser deletada.</param>
    Task RemoverAsync(int id);

    /// <summary>
    /// Método genérico para excluir um array de entidades.
    /// </summary>
    /// <param name="entityArray">Array de entidades a serem deletadas.</param>
    Task RemoverVariosAsync(TEntity[] entityArray);

    /// <summary>
    /// Método para salvar as alterações no banco de dados.
    /// </summary>
    /// <returns>Retorna verdadeiro se as alterações foram salvas com sucesso.</returns>
    Task<bool> SaveChangesAsync();
}