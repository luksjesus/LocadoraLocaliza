using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Infra.Data.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace Locadora.Infra.Data.Repository
{
    public class MidiaRepository : Repository<Midia>, IMidiaRepository
    {
        public MidiaRepository(LocadoraContext context) : base(context) { }

        public async Task<IEnumerable<Midia>> GetByName(string nome)
        {
            return await _context.Midias.AsNoTracking().Where(c => c.Descricao.Contains(nome)).ToListAsync();
        }
    }
}