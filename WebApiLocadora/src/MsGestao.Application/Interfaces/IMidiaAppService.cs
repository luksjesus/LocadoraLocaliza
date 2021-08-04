using Locadora.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Interfaces
{
    public interface IMidiaAppService : IDisposable
    {
        Task Add(MidiaViewModel MidiaViewModel);
        Task Update(MidiaViewModel MidiaViewModel);
        Task Delete(Guid id);

        Task<MidiaViewModel> GetById(Guid id);
        Task<MidiaViewModel> GetByIdNoTracking(Guid id);
        Task<IEnumerable<MidiaViewModel>> GetAll();
        Task<IEnumerable<MidiaViewModel>> GetByName(string nome);
    }
}
