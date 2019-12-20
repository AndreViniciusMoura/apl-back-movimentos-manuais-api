using apl_movimentos_manuais.Domain.Interfaces.Respositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace apl_movimentos_manuais.Infra.Persistence
{
    public interface IUnitOfWork
    {
        #region Repositories

        IMovimentoManualRepository MovimentoManualRepository { get; }

        IProdutoRepository ProdutoRepository { get; }

        #endregion

        DbContext Context { get; }

        void Commit();
    }
}
