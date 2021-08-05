using Locadora.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Locadora.Infra.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(p => p.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsUnicode(false);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(p => p.Cep)
                .IsRequired()
                .HasMaxLength(8)
                .IsUnicode(false);

            builder.Property(p => p.Logradouro)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(p => p.Cidade)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder.Property(p => p.Estado)
                .IsRequired()
                .HasMaxLength(2)
                .IsUnicode(false);

            builder.Property(p => p.Complemento)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
