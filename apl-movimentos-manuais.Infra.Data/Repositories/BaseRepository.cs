using apl_movimentos_manuais.Domain.Interfaces.Respositories;
using apl_movimentos_manuais.Infra.Persistence;
using apl_movimentos_manuais.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace apl_movimentos_manuais.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        #region Propriedades

        protected readonly MovimentosManuaisContext _dbContext;
        internal DbSet<T> dbSet;

        #endregion

        #region Construtor

        public BaseRepository(MovimentosManuaisContext dbContext)
        {
            _dbContext = dbContext;
            dbSet = _dbContext.Set<T>();
        }

        #endregion

        #region Methods

        public async Task<T> Get(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> Get(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<T> SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await _dbContext.Set<T>().AddRangeAsync(entities);
        }

        public async Task Remove(T entity)
        {
            await _dbContext.Set<T>().Remove(entity).ReloadAsync();
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
        }

        #endregion
    }
}
