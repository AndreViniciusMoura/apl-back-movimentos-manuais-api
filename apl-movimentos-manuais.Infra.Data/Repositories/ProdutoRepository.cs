using apl_movimentos_manuais.Domain.Entities;
using apl_movimentos_manuais.Domain.Interfaces.Respositories;
using apl_movimentos_manuais.Infra.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace apl_movimentos_manuais.Infra.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        #region Propriedades

        #endregion

        #region Construtor

        public ProdutoRepository(MovimentosManuaisContext context) : base(context)
        {
        }

        #endregion

        #region Metodos

        #endregion
    }
}
