using Portal.Core.Repositories;
using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Portal.Infraestructure.Persistance.Repositories
{
    public class EventoRepository : IEventRepository
    {
        private readonly PortalDbContext _dbcontext;
        public EventoRepository(PortalDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task AddAsync(Evento evento)
        {
            await _dbcontext.Eventos.AddAsync(evento);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<List<Evento>> GetAllAsync()
        {
            return await _dbcontext.Eventos.Where(u => u.IsDeleted.Equals(false)).ToListAsync();
        }
        public async Task<Evento> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Eventos.Where(c => c.IsDeleted.Equals(false) && c.Id == id).SingleOrDefaultAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
