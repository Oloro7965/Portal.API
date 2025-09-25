using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Core.Entities;

namespace Portal.Infrastructure.Configurations
{
    public class EventoConfiguration : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            // Nome da tabela
            builder.ToTable("Eventos");

            // Chave primária (herdada de BaseEntity)
            builder.HasKey(e => e.Id);

            // Propriedades
            builder.Property(e => e.titulo)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.descricao)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(e => e.data)
                   .IsRequired();

            builder.Property(e => e.local)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(e => e.area)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.IsDeleted)
                   .HasDefaultValue(false);

            // Relacionamento N:N com Usuario (palestrantes)
            /*builder.HasMany(e => e.Palestrante)
                   .WithMany(u => u.Eventos) // assumindo que Usuario possui lista de Eventos
                   .UsingEntity<Dictionary<string, object>>(
                       "EventoUsuario",
                       j => j.HasOne<Usuario>()
                             .WithMany()
                             .HasForeignKey("UsuarioId")
                             .OnDelete(DeleteBehavior.Cascade),
                       j => j.HasOne<Evento>()
                             .WithMany()
                             .HasForeignKey("EventoId")
                             .OnDelete(DeleteBehavior.Cascade),
                       j => j.HasKey("EventoId", "UsuarioId")
                   );*/
        }
    }
}
