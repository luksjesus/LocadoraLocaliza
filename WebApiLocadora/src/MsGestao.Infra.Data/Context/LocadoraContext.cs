using Locadora.Domain.Models;
using Locadora.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Locadora.Infra.Data.Context
{
    public class LocadoraContext : DbContext
    {
        public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<ItemLocacao> ItemsLocacao { get; set; }
        public DbSet<Midia> Midias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasSequence<int>("SequencialNumeroDaReserva").StartsAt(0).IncrementsBy(1);
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new ItemLocacaoMapping());
            modelBuilder.ApplyConfiguration(new LocacaoMapping());
            modelBuilder.ApplyConfiguration(new MidiaMapping());
            modelBuilder.ApplyConfiguration(new ProdutoMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}