using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Locadora.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepositoryRead<TEntity>, IRepositoryWrite<TEntity> where TEntity : Entity, new()
    {
        protected readonly LocadoraContext _context;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(LocadoraContext context)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Delete(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
        }

        /*
        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        */

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> GetByIdNoTracking(Guid id)
        {
            return await DbSet.AsNoTracking().Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        /*
        public async Task<IEnumerable<TEntity>> ObterTodosPaginado(int tamanhoPagina, int numeroRegistros)
        {
            return await DbSet.AsNoTracking().Take(numeroRegistros).Skip(tamanhoPagina).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> ObterTodosPaginadoPorColuna(int tamanhoPagina, int numeroRegistros, Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Take(numeroRegistros).Skip(tamanhoPagina).OrderBy(predicate).ToListAsync();
        }
        */

        public void Dispose()
        {
            _context.DisposeAsync();
        }
    }
}
