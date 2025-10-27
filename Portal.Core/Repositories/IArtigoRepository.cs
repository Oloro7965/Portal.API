using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Repositories
{
    public interface IArtigoRepository
    {
        Task<List<artigo>> GetAllAsync();
        Task<artigo> GetByIdAsync(Guid id);
        Task AddAsync(artigo artigo);
        Task<List<artigo>> SearchByKeywordsAsync(List<string> keywords);
        Task SaveChangesAsync();

    }
}
