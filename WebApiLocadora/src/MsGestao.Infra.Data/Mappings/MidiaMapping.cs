using Locadora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Data.Mappings
{
    public class MidiaMapping : IEntityTypeConfiguration<Midia>
    {
        public void Configure(EntityTypeBuilder<Midia> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Descricao)
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(p => p.Multa)
                .IsRequired();
        }
    }
}
