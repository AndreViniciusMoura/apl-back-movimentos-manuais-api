using apl_movimentos_manuais.Domain.Entities;
using apl_movimentos_manuais.Domain.Interfaces.Respositories;
using apl_movimentos_manuais.Domain.Interfaces.Services;
using apl_movimentos_manuais.Infra.Persistence;
using System;
using System.Collections.Generic;
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

        #endregion
    }
}
