using Microsoft.EntityFrameworkCore;
using ProEventos.Data.Contexts;
using ProEventos.Domain.Models;

namespace ProEventos.Data;

/// <summary>
/// Classe de persistência de dados.
/// </summary>
public class Persistence : IPersistence
{
    private readonly ProEventosContext _context;

    public Persistence(ProEventosContext context)
    {
        _context = context;
    }

    public void Adicionar<T>(T entity) where T : class
    {
        _context.Add(entity);
    }

    public void Atualizar<T>(T entity) where T : class
    {
        _context.Update(entity);
    }

    public void Excluir<T>(T entity) where T : class
    {
        _context.Remove(entity);
    }

    public void ExcluirVarios<T>(T[] entityArray) where T : class
    {
        _context.RemoveRange(entityArray);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Evento[]> ObterTodosEventosAsync(bool incluirPalestrantes = false)
    {
        IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

        if (incluirPalestrantes)
        {
            query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
        }

        query = query.OrderBy(e => e.Id);

        return await query.ToArrayAsync();
    }

    public async Task<Evento[]> ObterTodosEventosPorTemaAsync(string tema, bool incluirPalestrantes = false)
    {
        IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

        if (incluirPalestrantes)
        {
            query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
        }

        query = query.OrderBy(e => e.Id)
                     .Where(e => e.Tema.ToLower().Contains(tema.ToString().ToLower()));

        return await query.ToArrayAsync();
    }

    public async Task<Evento> ObterEventoPorIdAsync(int eventoId, bool incluirPalestrantes = false)
    {
        IQueryable<Evento> query = _context.Eventos
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

        if (incluirPalestrantes)
        {
            query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
        }

        query = query.OrderBy(e => e.Id)
                     .Where(e => e.Id == eventoId);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<Palestrante[]> ObterTodosPalestrantesAsync(bool incluirEventos = false)
    {
        IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedesSociais);

        if (incluirEventos)
        {
            query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
        }

        query = query.OrderBy(p => p.Id);

        return await query.ToArrayAsync();
    }

    public async Task<Palestrante[]> ObterTodosPalestrantesPorNomeAsync(string nome, bool incluirEventos = false)
    {
        IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedesSociais);

        if (incluirEventos)
        {
            query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
        }

        query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

        return await query.ToArrayAsync();
    }

    public async Task<Palestrante> ObterPalestrantePorIdAsync(int palestranteId, bool incluirEventos = false)
    {
        IQueryable<Palestrante> query = _context.Palestrantes
            .Include(p => p.RedesSociais);

        if (incluirEventos)
        {
            query = query
                .Include(p => p.PalestrantesEventos)
                .ThenInclude(pe => pe.Evento);
        }

        query = query.OrderBy(p => p.Id).Where(p => p.Id == palestranteId);

        return await query.FirstOrDefaultAsync();
    }
}