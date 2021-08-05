using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Locadora.Infra.Data.Repository
{
    public class LocacaoRepository : Repository<Locacao>, ILocacaoRepository
    {
        public LocacaoRepository(LocadoraContext context) : base(context) { }

        public override async Task<IEnumerable<Locacao>> GetAll()
        {
            return await _context.Locacoes
                .AsNoTracking()
                .Include(c => c.Cliente)
                .ToListAsync();
        }
        
        public override async Task<Locacao> GetById(Guid id)
        {
            return await _context.Locacoes
                .Where(c => c.Id == id)
                .AsNoTracking()
                .Include(c => c.Cliente)
                .Include(c => c.Itens ).ThenInclude(c => c.Produto).ThenInclude(c => c.Midia)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Locacao>> GetByIdCliente(Guid ClienteId)
        {
            return await _context.Locacoes
               .Where(c => c.ClienteId == ClienteId)
               .AsNoTracking()
               .Include(c => c.Cliente)
               .Include(c => c.Itens).ThenInclude(c => c.Produto).ThenInclude(c => c.Midia)
               .ToListAsync();
        }
    }
}