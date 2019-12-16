using System.Collections.Generic;
using System.Threading.Tasks;

namespace apl_movimentos_manuais.Domain.Interfaces.Respositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
    }
}
