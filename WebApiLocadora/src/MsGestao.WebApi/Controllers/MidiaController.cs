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
    public class MidiaController : MainController
    {
        private readonly IMidiaAppService _MidiaAppService;

        public MidiaController(IMidiaAppService MidiaAppService,
                                        INotificador notificador) : base(notificador)
        {
            _MidiaAppService = MidiaAppService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<MidiaViewModel>> GetAll()
        {
            return await _MidiaAppService.GetAll();
        }

        [HttpGet("GetById/{Id:Guid}")]
        public async Task<MidiaViewModel> GetById(Guid Id)
        {
            return await _MidiaAppService.GetById(Id);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(MidiaViewModel Midia)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                await _MidiaAppService.Add(Midia);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message, ex);
                NotificarErro("Erro ao adicionar Midia! " + ex.Message);
            }

            return CustomResponse(Midia);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(MidiaViewModel Midia)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            if (await _MidiaAppService.GetByIdNoTracking(Midia.Id) == null)
            {
                NotificarErro("O item não foi encontrado para alteração");
                return CustomResponse(Midia);
            }

            try
            {
                await _MidiaAppService.Update(Midia);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message, ex);
                NotificarErro("Erro ao atualizar Midia! " + ex.Message);
            }

            return CustomResponse(Midia);
        }

        [HttpDelete("Delete/{Id:Guid}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            if (await _MidiaAppService.GetByIdNoTracking(Id) == null)
            {
                NotificarErro("O item não foi encontrado para exclusão");
                return CustomResponse();
            }

            try
            {
                await _MidiaAppService.Delete(Id);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message, ex);
                NotificarErro("Erro ao excluir Midia! " + ex.Message);
            }

            return CustomResponse();
        }
    }
}
