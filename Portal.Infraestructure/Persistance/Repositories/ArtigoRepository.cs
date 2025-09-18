using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infraestructure.Persistance.Repositories
{
    public class ArtigoRepository : IArtigoRepository
    {
        private readonly PortalDbContext _dbContext;
        public ArtigoRepository(PortalDbContext _dbContext){
            _dbContext = _dbContext;
        }
        public async Task AddAsync(Artigo artigo)
        { 
            await_dbcontext.Artigo.AddAsync(room);
            await_dbcontext.SaveChangeAsync();

        }
        public async Task<List<Artigo>>GetAllAsync()
        {
            return await _dbcontext.Artigo.Where(u => u.IsDeleted.Equals(false)).

        }
        public async Task<Artigo> GetByIdAsync(Guid id)
        {
          return await _dbcontext.Artigo.Where(c=>c.IsDeleted.Equals(false) && c.Id == id)
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
