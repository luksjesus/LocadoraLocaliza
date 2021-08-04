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
    public class MidiaAppService : IMidiaAppService
    {
        private readonly IMapper _mapper;
        private readonly IMidiaRepository _MidiaRepository;
        private readonly IMidiaService _MidiaService;
        private readonly LocadoraContext _context;

        public MidiaAppService(IMidiaRepository MidiaRepository,
                                       IMapper mapper,
                                       IMidiaService MidiaService,
                                       LocadoraContext context)
        {
            _MidiaRepository = MidiaRepository;
            _MidiaService = MidiaService;
            _mapper = mapper;
            _context = context;
        }

        public async Task<MidiaViewModel> GetById(Guid id)
        {
            return _mapper.Map<MidiaViewModel>(await _MidiaRepository.GetById(id));
        }

        public async Task<MidiaViewModel> GetByIdNoTracking(Guid id)
        {
            return _mapper.Map<MidiaViewModel>(await _MidiaRepository.GetByIdNoTracking(id));
        }

        public async Task<IEnumerable<MidiaViewModel>> GetByName(string nome)
        {
            return _mapper.Map<IEnumerable<MidiaViewModel>>(await _MidiaRepository.GetByName(nome));
        }

        public async Task<IEnumerable<MidiaViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<MidiaViewModel>>(await _MidiaRepository.GetAll());
        }

        public async Task Add(MidiaViewModel MidiaViewModel)
        {
            var Midia = _mapper.Map<Midia>(MidiaViewModel);

            using (var transacao = _context.Database.BeginTransaction())
            {
                _MidiaService.Add(Midia);
                await _context.SaveChangesAsync();
                transacao.Commit();
            }
        }

        public async Task Update(MidiaViewModel MidiaViewModel)
        {
            var Midia = _mapper.Map<Midia>(MidiaViewModel);

            using (var transacao = _context.Database.BeginTransaction())
            {
                _MidiaService.Update(Midia);
                await _context.SaveChangesAsync();
                transacao.Commit();
            }
        }

        public async Task Delete(Guid id)
        {
            using (var transacao = _context.Database.BeginTransaction())
            {
                _MidiaService.Delete(id);
                await _context.SaveChangesAsync();
                transacao.Commit();
            }
        }

        public void Dispose()
        {
            _MidiaService.Dispose();
        }
    }
}
