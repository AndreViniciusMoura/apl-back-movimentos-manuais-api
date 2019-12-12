using apl_movimentos_manuais.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace apl_movimentos_manuais.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Propriedades

        public DbContext Context { get; }

        #endregion

        #region Construtor

        public UnitOfWork(DbContext context)
        {
            Context = context;
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
