using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Repositories
{
    public interface IComentarioRepository
    {
        Task<List<Comentario>> GetAllAsync();
        Task AddAsync(Comentario comentario);
        Task<List<Comentario>> GetByArtigoIdAsync(int artigoId);
        Task SaveChangesAsync();
    }
}
