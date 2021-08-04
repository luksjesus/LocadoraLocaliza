using Locadora.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Interfaces
{
    public interface IClienteAppService : IDisposable
    {
        Task Add(ClienteViewModel ClienteViewModel);
        Task Update(ClienteViewModel ClienteViewModel);
        Task Delete(Guid id);

        Task<ClienteViewModel> GetById(Guid id);
        Task<ClienteViewModel> GetByIdNoTracking(Guid id);
        Task<IEnumerable<ClienteViewModel>> GetAll();
        Task<IEnumerable<ClienteViewModel>> GetByName(string nome);
    }
}
