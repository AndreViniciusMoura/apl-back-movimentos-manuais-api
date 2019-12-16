using apl_movimentos_manuais.Domain.Interfaces.Respositories;
using apl_movimentos_manuais.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apl_movimentos_manuais.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        #region Propriedades

        protected readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Construtor

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _unitOfWork.Context.Set<T>().AsNoTracking().ToListAsync();
        }

        #endregion
    }
}
