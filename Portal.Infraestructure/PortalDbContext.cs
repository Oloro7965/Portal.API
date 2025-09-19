using Microsoft.EntityFrameworkCore;
using Portal.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Infraestructure
{
    public class PortalDbContext:DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Revista> Revistas { get; set; }

        public DbSet<Forum> Foruns { get; set; }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Keywords> keywords { get; set; }
        public DbSet<artigo> Artigos { get; set; }
        public DbSet<Postagem> Postagens { get; set; }
        public DbSet<Comentario> comentarios { get; set; }

        public PortalDbContext(DbContextOptions<PortalDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
