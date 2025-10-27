using Microsoft.EntityFrameworkCore;
using Portal.Core.Entities;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace Portal.Infraestructure.Persistance.Repositories
{
    public class ArtigoRepository : IArtigoRepository
    {
        private readonly PortalDbContext _dbcontext;
        public ArtigoRepository(PortalDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task AddAsync(artigo artigo)
        { 
            await _dbcontext.Artigos.AddAsync(artigo);
            await _dbcontext.SaveChangesAsync();

        }
        public async Task<List<artigo>>GetAllAsync()
        {
            return await _dbcontext.Artigos.Where(u => u.IsDeleted.Equals(false)).ToListAsync();

        }
        public async Task<artigo> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Artigos.Where(c => c.IsDeleted.Equals(false) && c.Id == id).SingleOrDefaultAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<artigo>> SearchByKeywordsAsync(List<string> keywords)
        {
            return await _dbcontext.Artigos
                .Include(a => a.keywords)
                .Where(a => a.keywords.Any(k => keywords.Contains(k.titulo)))
                .ToListAsync();
        }
    }
}
