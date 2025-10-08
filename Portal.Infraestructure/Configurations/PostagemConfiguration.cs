using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Core.Entities;

namespace Portal.Infrastructure.Configurations
{
    public class PostagemConfiguration : IEntityTypeConfiguration<Postagem>
    {
        public void Configure(EntityTypeBuilder<Postagem> builder)
        {
            // Nome da tabela
            builder.ToTable("Postagens");

            // Chave primária (herdada de BaseEntity)
            builder.HasKey(p => p.Id);

            // Propriedades
            builder.Property(p => p.conteudo)
                   .IsRequired()
                   .HasMaxLength(2000);

            builder.Property(p => p.IsDeleted)
                   .HasDefaultValue(false);

            // Relacionamento N:N com Comentario (ou 1:N dependendo do seu modelo)
            builder.HasMany(p => p.comentarios)
                   .WithOne(p=>p.postagem) // assumindo que Comentario não possui referência de volta
                   .HasForeignKey(p=>p.PostagemId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
