using Locadora.Domain.Enum;
using Locadora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(p => p.DataLancamento)
                .IsRequired();

            builder.Property(p => p.MidiaId)
                .IsRequired();

            builder.Property(p => p.TipoDeProduto)
                .HasConversion<int>()
                .HasDefaultValue(TipoDeProduto.Filme)
                .IsRequired();
        }
    }
}
