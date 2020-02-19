using apl_movimentos_manuais.Domain.Entities;
using apl_movimentos_manuais.Domain.Entities.Validations;
using apl_movimentos_manuais.Domain.Interfaces.Respositories;
using apl_movimentos_manuais.Domain.Interfaces.Services;
using apl_movimentos_manuais.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apl_movimentos_manuais.Services.Produtos
{
    public class ProdutoService : BaseService, IProdutoService
    {
        #region Properties

        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Construtor

        public ProdutoService(INotificadorService notificadorService, IUnitOfWork unitOfWork) : base(notificadorService)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _unitOfWork.ProdutoRepository.GetAll();
        }

        public async Task<Produto> GetById(Guid id)
        {
            return await _unitOfWork.ProdutoRepository.SingleOrDefault(p => p.CodProduto == id.ToString());
        }

        public async Task<bool> Adicionar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return false;

            if (_unitOfWork.ProdutoRepository.Find(p => p.DesProduto == produto.DesProduto).Result.Any())
            {
                Notificar("Já existe um produto com a descrição informada.");
                return false;
            }

            await _unitOfWork.ProdutoRepository.Add(produto);
            await _unitOfWork.SaveChanges();

            return true;
        }

        public async Task<bool> Atualizar(Produto produto)
        {
            if (!ExecutarValidacao(new ProdutoValidation(), produto)) return false;

            if (_unitOfWork.ProdutoRepository.Find(f => f.DesProduto == produto.DesProduto && f.CodProduto != produto.CodProduto).Result.Any())
            {
                Notificar("Já existe um produto com a descrição informada.");
                return false;
            }

            await _unitOfWork.ProdutoRepository.Update(produto);
            await _unitOfWork.SaveChanges();

            return true;
        }

        public async Task<bool> Remover(string codProduto)
        {
            var produto = _unitOfWork.ProdutoRepository.SingleOrDefault(p => p.CodProduto == codProduto.ToString()).Result;

            if (produto is null) return false;

            await _unitOfWork.ProdutoRepository.Delete(produto);
            await _unitOfWork.SaveChanges();

            return true;
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }

        #endregion
    }
}
