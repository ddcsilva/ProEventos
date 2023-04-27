using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ProEventos.Data.Contexts;
using ProEventos.Domain.Interfaces.Repositories;
using ProEventos.Domain.Models;

namespace ProEventos.Data.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    protected readonly ProEventosContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected Repository(ProEventosContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public virtual async Task AdicionarAsync(TEntity entity)
    {
        _dbSet.Add(entity);
        await SaveChangesAsync();
    }

    public virtual async Task AtualizarAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await SaveChangesAsync();
    }

    public virtual async Task RemoverAsync(int id)
    {
        _dbSet.Remove(new TEntity { Id = id });
        await SaveChangesAsync();
    }

    public virtual async Task RemoverVariosAsync(TEntity[] entityArray)
    {
        _dbSet.RemoveRange(entityArray);
        await SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> BuscarAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
    }

    public virtual async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) > 0;
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}