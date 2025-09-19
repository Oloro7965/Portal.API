using Microsoft.EntityFrameworkCore;
using Portal.Core.Entities;
using Portal.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infraestructure.Persistance.Repositories
{
    public class ComentarioRepository : IComentarioRepository
    {
        private readonly PortalDbContext _dbcontext;
        public ComentarioRepository(PortalDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task AddAsync(Comentario comentario)
        {
            await _dbcontext.comentarios.AddAsync(comentario);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<List<Comentario>> GetAllAsync()
        {
            return await _dbcontext.comentarios.Where(u => u.IsDeleted.Equals(false)).ToListAsync();
        }
        public async Task<Comentario> GetByIdAsync(Guid id)
        {
            return await _dbcontext.comentarios.Where(c => c.IsDeleted.Equals(false) && c.Id == id).SingleOrDefaultAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
