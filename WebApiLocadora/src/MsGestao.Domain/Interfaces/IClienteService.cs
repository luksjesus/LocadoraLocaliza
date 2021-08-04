using Locadora.Domain.Models;
using System;

namespace Locadora.Domain.Interfaces
{
    public interface IClienteService : IDisposable
    {
        bool Add(Cliente cliente);
        bool Update(Cliente cliente);
        void Delete(Guid id);
    }
}
