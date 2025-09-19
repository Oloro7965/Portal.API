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
    public class PostagemRepository : IPostagemRepository
    {
        private readonly PortalDbContext _dbcontext;
        public PostagemRepository(PortalDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Postagem postagem)
        {
            await _dbcontext.Postagens.AddAsync(postagem);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<List<Postagem>> GetAllAsync()
        {
            return await _dbcontext.Postagens.Where(u => u.IsDeleted.Equals(false)).ToListAsync();
        }
        public async Task<Postagem> GetByIdAsync (Guid id)
        {
            return await _dbcontext.Postagens.Where(c => c.IsDeleted.Equals(false) && c.Id == id).SingleOrDefaultAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
