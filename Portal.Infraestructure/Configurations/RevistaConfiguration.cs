using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Core.Entities;
using Portal.Core.Enums;

namespace Portal.Infrastructure.Configurations
{
    public class RevistaConfiguration : IEntityTypeConfiguration<Revista>
    {
        public void Configure(EntityTypeBuilder<Revista> builder)
        {
            // Chave primária (herdada de BaseEntity)
            builder.HasKey(r => r.Id);

            // Propriedades
            builder.Property(r => r.titulo)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(r => r.descricao)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(r => r.edicao)
                   .HasMaxLength(50);

            builder.Property(r => r.capa)
                   .HasMaxLength(500);

            builder.Property(r => r.publicacao)
                   .IsRequired();

            builder.Property(r => r.arquivopdf)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(r => r.area)
                   .IsRequired()
                   .HasConversion<int>(); // Enum para int

            builder.Property(r => r.IsDeleted)
                   .HasDefaultValue(false);

            // Relacionamento N:N com Usuario (autores)
            /* builder.HasMany(r => r.autores)
                   .WithMany(u => u.Revistas) // assumindo que Usuario tem lista de Revistas
                   .UsingEntity<Dictionary<string, object>>(
                       "RevistaUsuario",
                       j => j.HasOne<Usuario>()
                             .WithMany()
                             .HasForeignKey("UsuarioId")
                             .OnDelete(DeleteBehavior.Cascade),
                       j => j.HasOne<Revista>()
                             .WithMany()
                             .HasForeignKey("RevistaId")
                             .OnDelete(DeleteBehavior.Cascade),
                       j => j.HasKey("RevistaId", "UsuarioId")
                   );

            // Relacionamento N:N com Keywords
            builder.HasMany(r => r.keywords)
                   .WithMany(k => k.Revistas) // assumindo que Keywords tem lista de Revistas
                   .UsingEntity<Dictionary<string, object>>(
                       "RevistaKeyword",
                       j => j.HasOne<Keywords>()
                             .WithMany()
                             .HasForeignKey("KeywordId")
                             .OnDelete(DeleteBehavior.Cascade),
                       j => j.HasOne<Revista>()
                             .WithMany()
                             .HasForeignKey("RevistaId")
                             .OnDelete(DeleteBehavior.Cascade),
                       j => j.HasKey("RevistaId", "KeywordId")
                   );*/
        }
    }
}
