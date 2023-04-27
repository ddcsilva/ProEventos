using ProEventos.Domain.Models;

namespace ProEventos.Data;

/// <summary>
/// Classe de persistência de dados.
/// </summary>
public class Persistence : IPersistence
{
    private readonly Persistence _context;

    public Persistence(Persistence context)
    {
        _context = context;
    }

    public void Adicionar<T>(T entity) where T : class
    {
        _context.Adicionar(entity);
    }

    public void Atualizar<T>(T entity) where T : class
    {
        _context.Atualizar(entity);
    }

    public void Excluir<T>(T entity) where T : class
    {
        _context.Excluir(entity);
    }

    public void ExcluirVarios<T>(T[] entityArray) where T : class
    {
        _context.ExcluirVarios(entityArray);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync() > 0);
    }

    public Task<Evento> ObterEventoPorIdAsync(int eventoId, bool incluirPalestrantes)
    {
        throw new NotImplementedException();
    }

    public Task<Palestrante> ObterPalestrantePorIdAsync(int palestranteId, bool incluirEventos)
    {
        throw new NotImplementedException();
    }

    public Task<Evento[]> ObterTodosEventosAsync(bool incluirPalestrantes)
    {
        throw new NotImplementedException();
    }

    public Task<Evento[]> ObterTodosEventosPorTemaAsync(string tema, bool incluirPalestrantes)
    {
        throw new NotImplementedException();
    }

    public Task<Palestrante[]> ObterTodosPalestrantesAsync(bool incluirEventos)
    {
        throw new NotImplementedException();
    }

    public Task<Palestrante[]> ObterTodosPalestrantesPorNomeAsync(string nome, bool incluirEventos)
    {
        throw new NotImplementedException();
    }
}