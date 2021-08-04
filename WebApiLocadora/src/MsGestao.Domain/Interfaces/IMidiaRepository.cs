using Locadora.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces
{
    public interface IMidiaRepository : IRepositoryRead<Midia>, IRepositoryWrite<Midia>
    {
        Task<IEnumerable<Midia>> GetByName(string nome);
    }
}
