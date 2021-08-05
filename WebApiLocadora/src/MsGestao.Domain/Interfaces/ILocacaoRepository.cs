using Locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces
{
    public interface ILocacaoRepository : IRepositoryRead<Locacao>, IRepositoryWrite<Locacao>
    {
        Task<IEnumerable<Locacao>> GetByIdCliente(Guid ClienteId);
    }
}
