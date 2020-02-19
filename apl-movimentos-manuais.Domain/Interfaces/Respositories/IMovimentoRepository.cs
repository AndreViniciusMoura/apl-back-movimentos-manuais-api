using System;
using System.Collections.Generic;
using System.Text;

namespace apl_movimentos_manuais.Domain.Interfaces.Respositories
{
    public interface IMovimentoRepository<T> where T : class
    {
        void Insert(T entity);

        IEnumerable<T> GetAll();
    }
}
