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
    public class ProdutoController : MainController
    {
        private readonly IProdutoAppService _ProdutoAppService;

        public ProdutoController(IProdutoAppService ProdutoAppService,
                                        INotificador notificador) : base(notificador)
        {
            _ProdutoAppService = ProdutoAppService;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ProdutoViewModel>> GetAll()
        {
            return await _ProdutoAppService.GetAll();
        }

        [HttpGet("GetById/{Id:Guid}")]
        public async Task<ProdutoViewModel> GetById(Guid Id)
        {
            return await _ProdutoAppService.GetById(Id);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(ProdutoViewModel Produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            try
            {
                await _ProdutoAppService.Add(Produto);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message, ex);
                NotificarErro("Erro ao adicionar Produto! " + ex.Message);
            }

            return CustomResponse(Produto);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ProdutoViewModel Produto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            
            if (await _ProdutoAppService.GetByIdNoTracking(Produto.Id) == null)
            {
                NotificarErro("O item não foi encontrado para alteração");
                return CustomResponse(Produto);
            }

            try
            {
                await _ProdutoAppService.Update(Produto);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message, ex);
                NotificarErro("Erro ao atualizar Produto! " + ex.Message);
            }

            return CustomResponse(Produto);
        }

        [HttpDelete("Delete/{Id:Guid}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            if (await _ProdutoAppService.GetByIdNoTracking(Id) == null)
            {
                NotificarErro("O item não foi encontrado para exclusão");
                return CustomResponse();
            }

            try
            {
                await _ProdutoAppService.Delete(Id);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message, ex);
                NotificarErro("Erro ao excluir Produto! " + ex.Message);
            }

            return CustomResponse();
        }
    }
}
