using Locadora.Domain.Models;
using System;

namespace Locadora.Domain.Interfaces
{
    public interface IItemLocacaoService : IDisposable
    {
        bool Add(ItemLocacao itemLocacao);
        bool Update(ItemLocacao itemLocacao);
        void Delete(Guid id);
    }
}
