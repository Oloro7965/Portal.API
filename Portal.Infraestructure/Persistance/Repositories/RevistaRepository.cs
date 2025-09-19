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
            return await _dbcontext.Revistas.Where(u => u.IsDeleted.Equals(false)).ToListAsync();
        }
        public async Task<Revista> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Revistas.Where(c => c.IsDeleted.Equals(false) && c.Id == id).SingleOrDefaultAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
