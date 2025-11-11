using Portal.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infraestructure.Persistance.Repositories
{
    public class RevistaRepository : IRevistaRepository
    {
        private readonly PortalDbContext _dbcontext;
        public RevistaRepository(PortalDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task AddAsync(Revista revista)
        {
            await _dbcontext.Revistas.AddAsync(revista);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<List<Revista>> GetAllAsync()
        {
            //return await _dbcontext.Revistas.Where(u => u.IsDeleted.Equals(false)).ToListAsync();
            return await _dbcontext.Revistas
                   .Where(u => u.IsDeleted.Equals(false))
                    .Include(a => a.autores)
                    .Include(a => a.keywords)
                    .AsNoTracking()
                    .AsSplitQuery() // evita “cartesian explosion” em N:N
                    .ToListAsync();
        }
        public async Task<Revista> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Revistas.Where(c => c.IsDeleted.Equals(false) && c.Id == id)
                .Include(c => c.autores)
                .Include(c => c.keywords)
                .SingleOrDefaultAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Revista>> SearchByKeywordsAsync(List<string> keywords)
        {
            return await _dbcontext.Revistas
                .Include(a => a.keywords)
                .Where(a => a.keywords.Any(k => !k.IsDeleted && keywords.Contains(k.titulo)))
                .ToListAsync();
        }

        public async Task UpdateAsync(Revista revista)
        {
            _dbcontext.Revistas.Attach(revista); 
            await _dbcontext.SaveChangesAsync();
        }
    }
}
