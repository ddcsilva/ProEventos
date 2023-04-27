using Microsoft.EntityFrameworkCore;
using ProEventos.Data.Contexts;
using ProEventos.Domain.Interfaces.Repositories;
using ProEventos.Domain.Models;

namespace ProEventos.Data.Repositories;

public class PalestranteRepository : Repository<Palestrante>, IPalestranteRepository
{
    public PalestranteRepository(ProEventosContext context) : base(context) { }

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

        query = query
            .Where(p => p.Id == palestranteId)
            .OrderBy(p => p.Id);

        return await query.FirstOrDefaultAsync();
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

        query = query
            .Where(p => p.Nome.ToLower().Contains(nome.ToLower()))
            .OrderBy(p => p.Id);

        return await query.ToArrayAsync();
    }
}