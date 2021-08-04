using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(LocadoraContext context) : base(context) { }

        public async Task<IEnumerable<Produto>> GetByName(string nome)
        {
            return await _context.Produtos.AsNoTracking().Where(c => c.Nome.Contains(nome)).ToListAsync();
        }
    }
}