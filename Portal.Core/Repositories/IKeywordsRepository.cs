using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Repositories
{
    public interface IKeywordsRepository
    {
        Task<List<Keywords>> GetAllAsync();
        Task<Keywords> GetByIdAsync(int id);
        Task AddAsync(Keywords keywords);
        Task<List<Keywords>> GetByIdsAsync(List<int> ids);
        Task<List<Keywords>> GetByNamesAsync(List<string> keywords);
        Task SaveChangesAsync();
    }
}
