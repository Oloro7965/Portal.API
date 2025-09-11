using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Repositories
{
    public interface IPostagemRepository
    {
        Task<List<Postagem>> GetAllAsync();
        Task<Postagem> GetByIdAsync(Guid id);
        Task AddAsync(Postagem postagem);
        Task SaveChangesAsync();
    }
}
