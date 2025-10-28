using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Core.Entities;
using Portal.Core.Enums;

namespace Portal.Infrastructure.Configurations
{
    public class ArtigoConfiguration : IEntityTypeConfiguration<artigo>
    {
        public void Configure(EntityTypeBuilder<artigo> builder)
        {
            // Chave primária (herdada de BaseEntity)
            builder.HasKey(a => a.Id);

            // Propriedades
            builder.Property(a => a.titulo)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(a => a.descricao)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(a => a.publicacao)
                   .IsRequired();

            builder.Property(a => a.arquivopdf)
                   .HasColumnType("varbinary(max)")
                   .IsRequired(false);

            builder.Property(a => a.area)
                   .IsRequired()
                   .HasConversion<int>(); // Enum para int

            builder.Property(a => a.IsDeleted)
                   .HasDefaultValue(false);

            builder.HasMany(a => a.keywords)
                .WithMany(k => k.artigos)
                 .UsingEntity<Dictionary<string, object>>(
                 "ArtigoKeyword",
                 j => j.HasOne<Keywords>()
                 .WithMany()
                 .HasForeignKey("KeywordId")
                 .OnDelete(DeleteBehavior.Restrict),
                  j => j.HasOne<artigo>()
                 .WithMany()
                 .HasForeignKey("ArtigoId")
                 .OnDelete(DeleteBehavior.Restrict));

            // Relacionamentos
            /* builder
                 .HasMany(a => a.autores)
                 .WithMany(u => u.Artigos) // supondo que Usuario tem lista de Artigos
                 .UsingEntity<Dictionary<string, object>>(
                     "ArtigoUsuario",
                     j => j.HasOne<Usuario>().WithMany().HasForeignKey("UsuarioId").OnDelete(DeleteBehavior.Cascade),
                     j => j.HasOne<artigo>().WithMany().HasForeignKey("ArtigoId").OnDelete(DeleteBehavior.Cascade),
                     j => j.HasKey("ArtigoId", "UsuarioId")
                 );

             builder
                 .HasMany(a => a.keywords)
                 .WithMany(k => k.Artigos) // supondo que Keywords tem lista de Artigos
                 .UsingEntity<Dictionary<string, object>>(
                     "ArtigoKeyword",
                     j => j.HasOne<Keywords>().WithMany().HasForeignKey("KeywordId").OnDelete(DeleteBehavior.Cascade),
                     j => j.HasOne<artigo>().WithMany().HasForeignKey("ArtigoId").OnDelete(DeleteBehavior.Cascade),
                     j => j.HasKey("ArtigoId", "KeywordId")
                 );*/
        }
    }
}
