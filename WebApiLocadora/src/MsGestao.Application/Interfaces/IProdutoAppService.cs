using Locadora.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        Task Add(ProdutoViewModel ProdutoViewModel);
        Task Update(ProdutoViewModel ProdutoViewModel);
        Task Delete(Guid id);

        Task<ProdutoViewModel> GetById(Guid id);
        Task<ProdutoViewModel> GetByIdNoTracking(Guid id);
        Task<IEnumerable<ProdutoViewModel>> GetAll();
        Task<IEnumerable<ProdutoViewModel>> GetByName(string nome);
    }
}
