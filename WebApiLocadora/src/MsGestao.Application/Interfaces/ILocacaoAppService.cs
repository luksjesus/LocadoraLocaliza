using Locadora.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Interfaces
{
    public interface ILocacaoAppService : IDisposable
    {
        Task Add(LocacaoViewModel LocacaoViewModel);
        Task Update(LocacaoViewModel LocacaoViewModel);
        Task Delete(Guid id);

        Task<LocacaoViewModel> GetById(Guid id);
        Task<LocacaoViewModel> GetByIdNoTracking(Guid id);
        Task<IEnumerable<LocacaoViewModel>> GetAll();
    }
}
