using Locadora.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces
{
    public interface IProdutoRepository : IRepositoryRead<Produto>, IRepositoryWrite<Produto>
    {
        Task<IEnumerable<Produto>> GetByName(string nome);
    }
}
