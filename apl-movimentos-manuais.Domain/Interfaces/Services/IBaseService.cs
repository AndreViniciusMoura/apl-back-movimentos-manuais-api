using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace apl_movimentos_manuais.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
    }
}
