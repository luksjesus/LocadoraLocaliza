using Locadora.Domain.Interfaces;
using Locadora.Domain.Models;
using Locadora.Domain.Validations;
using Locadora.Domain.Notificador;
using System;

namespace Locadora.Domain.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
                
        public ClienteService(IClienteRepository clienteRepository,
                                    INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }
        
        public bool Add(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return false;

            _clienteRepository.Add(cliente);

            return true;
        }

        public bool Update(Cliente cliente)
        {
            if (!ExecutarValidacao(new ClienteValidation(), cliente)) return false;

            _clienteRepository.Update(cliente);

            return true;
        }

        public void Delete(Guid id)
        {
            _clienteRepository.Delete(id);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
        }     
    }
}
