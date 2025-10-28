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

            builder.Property(r => r.capa)
                .HasColumnType("varbinary(max)")
                .IsRequired(false);

            builder.Property(r => r.publicacao)
                   .IsRequired();

            builder.Property(r => r.arquivopdf)
                   .HasColumnType("varbinary(max)")
                    .IsRequired(false);

            builder.Property(r => r.area)
                   .IsRequired()
                   .HasConversion<int>(); // Enum para int

            builder.Property(r => r.IsDeleted)
                   .HasDefaultValue(false);

            builder.HasMany(r => r.keywords)
                   .WithMany(k => k.revistas) // assumindo que Keywords tem lista de Revistas
                   .UsingEntity<Dictionary<string, object>>(
                       "RevistaKeyword",
                       j => j.HasOne<Keywords>()
                             .WithMany()
                             .HasForeignKey("KeywordId")
                             .OnDelete(DeleteBehavior.Restrict),
                       j => j.HasOne<Revista>()
                             .WithMany()
                             .HasForeignKey("RevistaId")
                             .OnDelete(DeleteBehavior.Restrict),
                       j => j.HasKey("RevistaId", "KeywordId")
                   );
        }
    }
}
