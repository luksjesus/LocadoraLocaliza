using Locadora.Domain.Enum;
using Locadora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Data.Mappings
{
    public class LocacaoMapping : IEntityTypeConfiguration<Locacao>
    {
        public void Configure(EntityTypeBuilder<Locacao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(p => p.DataCadastro)
                .IsRequired();

            builder.Property(p => p.ValorTotal)
                .IsRequired();

            builder.Property(p => p.Status)
                .IsRequired();

            builder.Property(p => p.Status)
                .HasConversion<int>()
                .HasDefaultValue(StatusDaVenda.AguardandoLiberacao)
                .IsRequired();
        }
    }
}
