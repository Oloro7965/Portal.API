using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Repositories
{
    public interface IRevistaRepository
    {
        Task<List<Revista>> GetAllAsync();
        Task<Revista> GetByIdAsync(Guid id);
        Task AddAsync(Revista revista);
        Task<List<Revista>> SearchByKeywordsAsync(List<string> keywords);
        Task SaveChangesAsync();
    }
}
