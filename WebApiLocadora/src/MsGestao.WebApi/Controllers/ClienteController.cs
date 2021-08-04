using Locadora.Application.Interfaces;
using Locadora.Application.ViewModels;
using Locadora.Domain.Notificador;
using Locadora.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.Api.Controllers
{
    [Route("api/[controller]")]
    public class ClienteController : MainController
    {
        private readonly IClienteAppService _ClienteAppService;

        public ClienteController(IClienteAppService ClienteAppService,
                                        INotificador notificador) : base(notificador)
        {
            _ClienteAppService = ClienteAppService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ClienteViewModel>> GetAll()
        {
            return await _ClienteAppService.GetAll();
        }

        [HttpGet("GetById/{Id:Guid}")]
        public async Task<ClienteViewModel> GetById(Guid Id)
        {
            return await _ClienteAppService.GetById(Id);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ClienteViewModel Cliente)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                await _ClienteAppService.Add(Cliente);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message, ex);
                NotificarErro("Erro ao adicionar Cliente! " + ex.Message);
            }

            return CustomResponse(Cliente);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ClienteViewModel Cliente)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            if (await _ClienteAppService.GetByIdNoTracking(Cliente.Id) == null)
            {
                NotificarErro("O item não foi encontrado para alteração");
                return CustomResponse(Cliente);
            }

            try
            {
                await _ClienteAppService.Update(Cliente);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message, ex);
                NotificarErro("Erro ao atualizar Cliente! " + ex.Message);
            }

            return CustomResponse(Cliente);
        }

        [HttpDelete("Delete/{Id:Guid}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            if (await _ClienteAppService.GetByIdNoTracking(Id) == null)
            {
                NotificarErro("O item não foi encontrado para exclusão");
                return CustomResponse();
            }

            try
            {
                await _ClienteAppService.Delete(Id);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message, ex);
                NotificarErro("Erro ao excluir Cliente! " + ex.Message);
            }

            return CustomResponse();
        }
    }
}
