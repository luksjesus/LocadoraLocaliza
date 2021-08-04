using Locadora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Data.Mappings
{
    public class ItemLocacaoMapping : IEntityTypeConfiguration<ItemLocacao>
    {
        public void Configure(EntityTypeBuilder<ItemLocacao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(p => p.LocacaoId)
                .IsRequired();

            builder.Property(p => p.ProdutoId)
                .IsRequired();
        }
    }
}
