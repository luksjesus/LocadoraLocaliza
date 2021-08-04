using Locadora.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Interfaces
{
    public interface IItemLocacaoAppService : IDisposable
    {
        Task Add(ItemLocacaoViewModel ItemLocacaoViewModel);
        Task Update(ItemLocacaoViewModel ItemLocacaoViewModel);
        Task Delete(Guid id);

        Task<ItemLocacaoViewModel> GetById(Guid id);
        Task<ItemLocacaoViewModel> GetByIdNoTracking(Guid id);
        Task<IEnumerable<ItemLocacaoViewModel>> GetAll();
    }
}
