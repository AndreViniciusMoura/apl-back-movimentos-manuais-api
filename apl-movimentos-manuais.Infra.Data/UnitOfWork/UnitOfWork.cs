using apl_movimentos_manuais.Domain.Interfaces.Respositories;
using apl_movimentos_manuais.Infra.Data.Repositories;
using apl_movimentos_manuais.Infra.Persistence;
using apl_movimentos_manuais.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace apl_movimentos_manuais.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Propriedades

        #region Repositories

        public IMovimentoManualRepository MovimentoManualRepository { get; private set; }

        public IProdutoRepository ProdutoRepository { get; private set; }

        #endregion

        public DbContext Context { get; }

        #endregion

        #region Construtor

        public UnitOfWork(MovimentosManuaisContext context)
        {
            Context = context;
            MovimentoManualRepository = new MovimentoManualRepository(context);
            ProdutoRepository = new ProdutoRepository(context);
        }

        #endregion

        #region Metodos

        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();

        }

        #endregion
    }
}
