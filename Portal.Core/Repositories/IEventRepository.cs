using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Core.Repositories
{
    public interface IEventRepository
    {
        Task<List<Evento>> GetAllAsync();
        Task<Evento> GetByIdAsync(Guid id);
        Task AddAsync(Evento evento);
        Task SaveChangesAsync();
    }
}
