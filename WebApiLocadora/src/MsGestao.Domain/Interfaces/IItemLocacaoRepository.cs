using Locadora.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces
{
    public interface IItemLocacaoRepository : IRepositoryRead<ItemLocacao>, IRepositoryWrite<ItemLocacao>
    {
    }
}
