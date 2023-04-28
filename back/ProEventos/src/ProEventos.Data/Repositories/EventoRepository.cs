using Microsoft.EntityFrameworkCore;
using ProEventos.Data.Contexts;
using ProEventos.Domain.Interfaces.Repositories;
using ProEventos.Domain.Models;

namespace ProEventos.Data.Repositories;

public class EventoRepository : Repository<Evento>, IEventoRepository
{
    public EventoRepository(ProEventosContext context) : base(context) { }

    public async Task<IEnumerable<Evento>> ObterTodosEventosAsync(bool incluirPalestrantes = false)
    {
        IQueryable<Evento> query = _context.Eventos
            .AsNoTracking()
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

    public async Task<Evento> ObterEventoPorIdAsync(int eventoId, bool incluirPalestrantes = false)
    {
        IQueryable<Evento> query = _context.Eventos
            .AsNoTracking()
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

        if (incluirPalestrantes)
        {
            query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
        }

        query = query
            .Where(e => e.Id == eventoId)
            .OrderBy(e => e.Id);

        return await query.FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Evento>> ObterTodosEventosPorTemaAsync(string tema, bool incluirPalestrantes = false)
    {
        IQueryable<Evento> query = _context.Eventos
            .AsNoTracking()
            .Include(e => e.Lotes)
            .Include(e => e.RedesSociais);

        if (incluirPalestrantes)
        {
            query = query
                .Include(e => e.PalestrantesEventos)
                .ThenInclude(pe => pe.Palestrante);
        }

        query = query
            .Where(e => e.Tema.ToLower().Contains(tema.ToLower()))
            .OrderBy(e => e.Id);

        return await query.ToArrayAsync();
    }
}