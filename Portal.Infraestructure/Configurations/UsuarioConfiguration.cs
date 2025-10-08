using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Core.Entities;
using Portal.Core.Enums;

namespace Portal.Infrastructure.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            // Chave primária (herdada de BaseEntity)
            builder.HasKey(u => u.Id);

            // Propriedades
            builder.Property(u => u.NomeCompleto)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(u => u.email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(u => u.senhaHash)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(u => u.tipoUsuario)
                   .IsRequired()
                   .HasConversion<int>(); // Enum para int

            builder.Property(u => u.IsDeleted)
                   .HasDefaultValue(false);

            // Relacionamentos N:N com Artigos
            builder.HasMany(u => u.artigos)
                   .WithMany(a => a.autores) // já configurado no ArtigoConfiguration
                   .UsingEntity<Dictionary<string, object>>(
                       "ArtigoUsuario",
                       j => j.HasOne<artigo>().WithMany().HasForeignKey("ArtigoId").OnDelete(DeleteBehavior.Restrict),
                       j => j.HasOne<Usuario>().WithMany().HasForeignKey("UsuarioId").OnDelete(DeleteBehavior.Restrict),
                       j => j.HasKey("ArtigoId", "UsuarioId")
                   );

            // Relacionamentos N:N com Postagens
            /*builder.HasMany(u => u.postagens)
                   .WithMany(p => p.usuarios) // se Postagem tiver lista de usuarios (ou criar tabela de junção)
                   .UsingEntity<Dictionary<string, object>>(
                       "UsuarioPostagem",
                       j => j.HasOne<Postagem>().WithMany().HasForeignKey("PostagemId").OnDelete(DeleteBehavior.Cascade),
                       j => j.HasOne<Usuario>().WithMany().HasForeignKey("UsuarioId").OnDelete(DeleteBehavior.Cascade),
                       j => j.HasKey("UsuarioId", "PostagemId")
                   );*/

            // Relacionamentos N:N com Revistas
            builder.HasMany(u => u.RevistasPublicadas)
                .WithMany(r => r.autores)
                   .UsingEntity<Dictionary<string, object>>(
                    "RevistaUsuario", // nome da tabela de junção
                j => j
                .HasOne<Revista>()
                .WithMany()
                .HasForeignKey("RevistaId")
                .OnDelete(DeleteBehavior.Restrict),
                j => j
                .HasOne<Usuario>()
                .WithMany()
                .HasForeignKey("UsuarioId")
                .OnDelete(DeleteBehavior.Restrict),
            j =>
            {
                j.HasKey("RevistaId", "UsuarioId");
                j.ToTable("RevistaUsuario");
            });

            builder.HasMany(u => u.EventosComoPalestrante)
                .WithMany(e => e.Palestrantes)
                .UsingEntity<Dictionary<string, object>>(
                "EventoUsuario",
                j => j.HasOne<Evento>()
                .WithMany()
                .HasForeignKey("EventoId")
                .OnDelete(DeleteBehavior.Restrict),
                j => j.HasOne<Usuario>()
                .WithMany()
                .HasForeignKey("UsuarioId")
                .OnDelete(DeleteBehavior.Restrict),
                j =>
            {
                j.HasKey("EventoId", "UsuarioId");
                j.ToTable("EventoUsuario");
            });
            builder.HasMany(u => u.postagens)
                   .WithOne(x => x.usuario) // Comentario não possui referência de volta
                   .HasForeignKey(x => x.IdUsuario)
                   .OnDelete(DeleteBehavior.Restrict);
            // Relacionamentos 1:N com Comentarios
            builder.HasMany(u => u.comentarios)
                   .WithOne(x => x.Usuario) // Comentario não possui referência de volta
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
