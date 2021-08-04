using Locadora.Domain.Models;
using System;

namespace Locadora.Domain.Interfaces
{
    public interface ILocacaoService : IDisposable
    {
        bool Add(Locacao locacao);
        bool Update(Locacao locacao);
        void Delete(Guid id);
    }
}
