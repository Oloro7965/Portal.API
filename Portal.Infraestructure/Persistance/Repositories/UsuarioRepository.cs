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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly PortalDbContext _dbcontext;
        public UsuarioRepository(PortalDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task AddAsync(Usuario usuario)
        {
            await _dbcontext.Usuarios.AddAsync(usuario);
            await _dbcontext.SaveChangesAsync();
        }
        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _dbcontext.Usuarios.Where(u => u.IsDeleted.Equals(false)).ToListAsync();
        }

        public async Task<Usuario> GetByEmailAsync(string Email)
        {
            return await _dbcontext.Usuarios.Where(c => c.email == Email)

            .SingleOrDefaultAsync();
        }

        public async Task<Usuario> GetByIdAsync(Guid id)
        {
            return await _dbcontext.Usuarios.Where(c => c.Id == id).SingleOrDefaultAsync();
        }

        public async Task<List<Usuario>> GetByNamesAsync(List<string> autores)
        {
            return await _dbcontext.Usuarios
            .Where(u=> autores.Contains(u.NomeCompleto))
            .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
