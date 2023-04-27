using System.Linq.Expressions;
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
    /// Método genérico para buscar entidades que atendam a um predicado.
    /// </summary>
    /// <param name="predicate">Predicado a ser atendido.</param>
    /// <returns>Retorna uma lista de entidades que atendam ao predicado.</returns>
    Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate);

    /// <summary>
    /// Método para salvar as alterações no banco de dados.
    /// </summary>
    /// <returns>Retorna verdadeiro se as alterações foram salvas com sucesso.</returns>
    Task<bool> SaveChangesAsync();
}