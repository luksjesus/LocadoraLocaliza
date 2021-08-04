using Locadora.Domain.Models;
using System;

namespace Locadora.Domain.Interfaces
{
    public interface IProdutoService : IDisposable
    {
        bool Add(Produto produto);
        bool Update(Produto produto);
        void Delete(Guid id);
    }
}
