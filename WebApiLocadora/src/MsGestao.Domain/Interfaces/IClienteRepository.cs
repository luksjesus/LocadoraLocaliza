using Locadora.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces
{
    public interface IClienteRepository : IRepositoryRead<Cliente>, IRepositoryWrite<Cliente>
    {
        Task<IEnumerable<Cliente>> GetByName(string nome);
    }
}
