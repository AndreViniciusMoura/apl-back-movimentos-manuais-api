using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace apl_movimentos_manuais.Domain.Interfaces.Respositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Get(long id);

        Task<T> Get(int id);

        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);

        Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate);

        Task Add(T entity);

        Task AddRange(IEnumerable<T> entities);

        Task Remove(T entity);

        Task RemoveRange(IEnumerable<T> entities);

    }
}
