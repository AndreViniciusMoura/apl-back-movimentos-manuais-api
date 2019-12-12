using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace apl_movimentos_manuais.Infra.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }

        void Commit();
    }
}
