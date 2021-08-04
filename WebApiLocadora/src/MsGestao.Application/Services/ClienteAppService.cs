using AutoMapper;
using Locadora.Application.Interfaces;
using Locadora.Application.ViewModels;
using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IMapper _mapper;
        private readonly IClienteRepository _ClienteRepository;
        private readonly IClienteService _ClienteService;
        private readonly LocadoraContext _context;

        public ClienteAppService(IClienteRepository ClienteRepository,
                                       IMapper mapper,
                                       IClienteService ClienteService,
                                       LocadoraContext context)
        {
            _ClienteRepository = ClienteRepository;
            _ClienteService = ClienteService;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ClienteViewModel> GetById(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(await _ClienteRepository.GetById(id));
        }

        public async Task<ClienteViewModel> GetByIdNoTracking(Guid id)
        {
            return _mapper.Map<ClienteViewModel>(await _ClienteRepository.GetByIdNoTracking(id));
        }

        public async Task<IEnumerable<ClienteViewModel>> GetByName(string nome)
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _ClienteRepository.GetByName(nome));
        }

        public async Task<IEnumerable<ClienteViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(await _ClienteRepository.GetAll());
        }

        public async Task Add(ClienteViewModel ClienteViewModel)
        {
            var cliente = _mapper.Map<Cliente>(ClienteViewModel);

            using (var transacao = _context.Database.BeginTransaction())
            {
                _ClienteService.Add(cliente);
                await _context.SaveChangesAsync();
                transacao.Commit();
            }
        }

        public async Task Update(ClienteViewModel ClienteViewModel)
        {
            var cliente = _mapper.Map<Cliente>(ClienteViewModel);

            using (var transacao = _context.Database.BeginTransaction())
            {
                _ClienteService.Update(cliente);
                await _context.SaveChangesAsync();
                transacao.Commit();
            }
        }

        public async Task Delete(Guid id)
        {
            using (var transacao = _context.Database.BeginTransaction())
            {
                _ClienteService.Delete(id);
                await _context.SaveChangesAsync();
                transacao.Commit();
            }
        }

        public void Dispose()
        {
            _ClienteService.Dispose();
        }
    }
}
