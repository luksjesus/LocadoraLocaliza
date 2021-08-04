using Locadora.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces
{
    public interface ILocacaoRepository : IRepositoryRead<Locacao>, IRepositoryWrite<Locacao>
    {
    }
}
