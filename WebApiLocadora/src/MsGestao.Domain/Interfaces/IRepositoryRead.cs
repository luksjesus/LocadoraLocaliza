using Locadora.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Locadora.Domain.Interfaces
{
    public interface IRepositoryRead<TEntity> : IDisposable where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<TEntity> GetByIdNoTracking(Guid id);
        // Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);
        // Task<IEnumerable<TEntity>> ObterTodosPaginado(int tamanhoPagina, int numeroRegistros);
    } 
}
