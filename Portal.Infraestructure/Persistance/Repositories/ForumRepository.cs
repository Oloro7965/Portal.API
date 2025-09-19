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
    public class ForumRepository : IForumRepository
    {
        private readonly PortalDbContext _dbcontext;
        public ForumRepository(PortalDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task AddAsync(Forum forum)
        {
            await _dbcontext.Foruns.AddAsync(forum);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<List<Forum>> GetAllAsync()
        {
            return await _dbcontext.Foruns.Where(u => u.IsDeleted.Equals(false)).ToListAsync();
        }
        public async Task<Forum>GetByIdAsync(Guid id)
        {
            return await _dbcontext.Foruns.Where(c => c.IsDeleted.Equals(false) && c.Id == id).SingleOrDefaultAsync();
        }
        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
