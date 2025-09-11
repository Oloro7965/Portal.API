using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Repositories
{
    public interface IForumRepository
    {
        Task<List<Forum>> GetAllAsync();
        Task<Forum> GetByIdAsync(Guid id);
        Task AddAsync(Forum forum);
        Task SaveChangesAsync();
    }
}
