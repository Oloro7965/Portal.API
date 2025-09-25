using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Core.Entities;
using Portal.Core.Enums;

namespace Portal.Infrastructure.Configurations
{
    public class ForumConfiguration : IEntityTypeConfiguration<Forum>
    {
        public void Configure(EntityTypeBuilder<Forum> builder)
        {
            // Nome da tabela
            builder.ToTable("Foruns");

            // Chave primária (herdada de BaseEntity)
            builder.HasKey(f => f.Id);

            // Propriedades
            builder.Property(f => f.titulo)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(f => f.descricao)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(f => f.area)
                   .IsRequired()
                   .HasConversion<int>(); // Enum para int

            builder.Property(f => f.IsDeleted)
                   .HasDefaultValue(false);

            // Relacionamento N:N com Postagem
            /*builder.HasMany(f => f.postagem)
                   .WithMany(p => p.Foruns) // assumindo que Postagem tem lista de Foruns
                   .UsingEntity<Dictionary<string, object>>(
                       "ForumPostagem",
                       j => j.HasOne<Postagem>()
                             .WithMany()
                             .HasForeignKey("PostagemId")
                             .OnDelete(DeleteBehavior.Cascade),
                       j => j.HasOne<Forum>()
                             .WithMany()
                             .HasForeignKey("ForumId")
                             .OnDelete(DeleteBehavior.Cascade),
                       j => j.HasKey("ForumId", "PostagemId")
                   );*/
        }
    }
}
