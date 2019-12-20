using apl_movimentos_manuais.Api.ViewModels;
using apl_movimentos_manuais.Domain.Interfaces.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apl_movimentos_manuais.Api.Controllers.V1
{
    /// <summary>
    /// Controller Produtos
    /// </summary>
    //[ApiVersion("1.0")]
    [Route("apl-movimentos-manuais/api/[controller]")]
    public class ProdutosController : MainController
    {
        #region Propriedades

        protected readonly IProdutoService _produtoService;
        private readonly INotificadorService _notificadorService;
        private readonly IMapper _mapper;

        #endregion

        #region Contrutor

        public ProdutosController(IProdutoService produtoService,
                                  INotificadorService notificadorService,
                                  IMapper mapper)
        {
            _produtoService = produtoService;
            _notificadorService = notificadorService;
            _mapper = mapper;
        }

        #endregion

        #region Metodos

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoViewModel>>> GetProdutos()
        {
            try
            {
                var produtos = await _produtoService.GetAll();

                var produtosViewModel = _mapper.Map<IEnumerable<ProdutoViewModel>>(produtos);

                return Ok(produtosViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> GetProdutoById(Guid id)
        {
            var produto = await _produtoService.GetById(id);

            var produtoViewModel = _mapper.Map<ProdutoViewModel>(produto);

            return Ok(produtoViewModel);
        }

        #endregion
    }
}
