using System.Collections.Generic;

namespace apl_movimentos_manuais.Domain.Interfaces.Respositories
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
