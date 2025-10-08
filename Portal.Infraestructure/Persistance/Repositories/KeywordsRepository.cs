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
    public class KeywordsRepository : IKeywordsRepository
    {
        private readonly PortalDbContext _dbcontext;

        public KeywordsRepository(PortalDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Keywords keywords)
        {
            await _dbcontext.keywords.AddAsync(keywords);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Keywords>> GetAllAsync()
        {
            return await _dbcontext.keywords.ToListAsync();
        }

        public async Task<Keywords> GetByIdAsync(Guid id)
        {

            return await _dbcontext.keywords.Where(c => c.Id == id).SingleOrDefaultAsync();

        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
