using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Core.Entities;

namespace Portal.Infrastructure.Configurations
{
    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            // Nome da tabela
            builder.ToTable("Comentarios");

            // Chave primária (herdada de BaseEntity)
            builder.HasKey(c => c.Id);

            // Propriedades
            builder.Property(c => c.conteudo)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(c => c.IsDeleted)
                   .HasDefaultValue(false);
        }
    }
}
