using apl_movimentos_manuais.Api.ViewModels;
using apl_movimentos_manuais.Domain.Entities;
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
    [ApiVersion("1.0")]
    [Route("apl-movimentos-manuais/api/v{version:apiVersion}/[controller]")]
    public class ProdutosController : MainController
    {
        #region Propriedades

        protected readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        #endregion

        #region Contrutor

        public ProdutosController(IProdutoService produtoService,
                                  INotificadorService notificadorService,
                                  IMapper mapper) : base(notificadorService)
        {
            _produtoService = produtoService;
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

                return CustomResponse(produtosViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{codProduto:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> GetProdutoById(Guid codProduto)
        {
            try
            {
                var produto = await _produtoService.GetById(codProduto);

                var produtoViewModel = _mapper.Map<ProdutoViewModel>(produto);

                return CustomResponse(produtoViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoViewModel>> Adicionar(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var produto = _mapper.Map<Produto>(produtoViewModel);

            await _produtoService.Adicionar(produto);

            produtoViewModel = _mapper.Map<ProdutoViewModel>(produto);

            return CustomResponse(produtoViewModel);
        }

        [HttpPut("{codProduto:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Atualizar(Guid codProduto, ProdutoViewModel produtoViewModel)
        {
            if (codProduto.ToString().ToUpper() != produtoViewModel.CodProduto.ToUpper())
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(produtoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var produto = _mapper.Map<Produto>(produtoViewModel);

            var result = await _produtoService.Atualizar(produto);

            if (!result) return BadRequest();

            return CustomResponse(produtoViewModel);

        }

        [HttpDelete("{codProduto:guid}")]
        public async Task<ActionResult<ProdutoViewModel>> Excluir(Guid codProduto)
        {
            var produtoViewModel = await _produtoService.GetById(codProduto);

            if (produtoViewModel is null) return NotFound();

            await _produtoService.Remover(produtoViewModel.CodProduto.ToString());

            return CustomResponse(produtoViewModel);
        }


        #endregion
    }
}
