using Locadora.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces
{
    public interface IRepositoryWrite<TEntity> : IDisposable where TEntity : Entity
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Delete(Guid id);
    }
}
