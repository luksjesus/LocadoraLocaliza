using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Domain.Validations;
using Locadora.Domain.Notificador;
using System;

namespace Locadora.Domain.Services
{
    public class MidiaService : BaseService, IMidiaService
    {
        private readonly IMidiaRepository _MidiaRepository;
                
        public MidiaService(IMidiaRepository MidiaRepository,
                                    INotificador notificador) : base(notificador)
        {
            _MidiaRepository = MidiaRepository;
        }
        
        public bool Add(Midia midia)
        {
            if (!ExecutarValidacao(new MidiaValidation(), midia)) return false;

            _MidiaRepository.Add(midia);

            return true;
        }

        public bool Update(Midia midia)
        {
            if (!ExecutarValidacao(new MidiaValidation(), midia)) return false;

            _MidiaRepository.Update(midia);

            return true;
        }

        public void Delete(Guid id)
        {
            _MidiaRepository.Delete(id);
        }

        public void Dispose()
        {
            _MidiaRepository.Dispose();
        }     
    }
}
