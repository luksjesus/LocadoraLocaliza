using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Infra.Data.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(LocadoraContext context) : base(context) { }

        public async Task<IEnumerable<Cliente>> GetByName(string nome)
        {
            return await _context.Clientes.AsNoTracking().Where(c => c.Nome.Contains(nome)).ToListAsync();
        }
    }
}