using Locadora.Domain.Models;
using System;

namespace Locadora.Domain.Interfaces
{
    public interface IMidiaService : IDisposable
    {
        bool Add(Midia midia);
        bool Update(Midia midia);
        void Delete(Guid id);
    }
}
