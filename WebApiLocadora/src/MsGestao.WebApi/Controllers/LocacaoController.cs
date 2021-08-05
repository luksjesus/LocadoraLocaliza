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
    public class LocacaoController : MainController
    {
        private readonly ILocacaoAppService _LocacaoAppService;

        public LocacaoController(ILocacaoAppService LocacaoAppService,
                                        INotificador notificador) : base(notificador)
        {
            _LocacaoAppService = LocacaoAppService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<LocacaoViewModel>> GetAll()
        {
            return await _LocacaoAppService.GetAll();
        }

        [HttpGet("GetById/{Id:Guid}")]
        public async Task<LocacaoViewModel> GetById(Guid Id)
        {
            return await _LocacaoAppService.GetById(Id);
        }

        [HttpGet("GetByIdCliente/{Id:Guid}")]
        public async Task<IEnumerable<LocacaoViewModel>> GetByIdCliente(Guid ClienteId)
        {
            return await _LocacaoAppService.GetByIdCliente(ClienteId);
        }

        [HttpGet("CalcularTotalPraPagamento/{LocacaoId:Guid}/{DataEntrega}")]
        public async Task<LocacaoViewModel> CalcularTotalPraPagamento(Guid LocacaoId, DateTime DataEntrega)
        {
            return await _LocacaoAppService.CalcularTotalPraPagamento(LocacaoId, DataEntrega);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(LocacaoViewModel Locacao)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                await _LocacaoAppService.Add(Locacao);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message, ex);
                NotificarErro("Erro ao adicionar Locacao! " + ex.Message);
            }

            return CustomResponse(Locacao);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(LocacaoViewModel Locacao)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            if (await _LocacaoAppService.GetByIdNoTracking(Locacao.Id) == null)
            {
                NotificarErro("O item não foi encontrado para alteração");
                return CustomResponse(Locacao);
            }

            try
            {
                await _LocacaoAppService.Update(Locacao);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message, ex);
                NotificarErro("Erro ao atualizar Locacao! " + ex.Message);
            }

            return CustomResponse(Locacao);
        }

        [HttpDelete("Delete/{Id:Guid}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            if (await _LocacaoAppService.GetByIdNoTracking(Id) == null)
            {
                NotificarErro("O item não foi encontrado para exclusão");
                return CustomResponse();
            }

            try
            {
                await _LocacaoAppService.Delete(Id);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message, ex);
                NotificarErro("Erro ao excluir Locacao! " + ex.Message);
            }

            return CustomResponse();
        }
    }
}
