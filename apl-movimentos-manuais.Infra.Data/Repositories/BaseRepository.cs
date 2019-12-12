using apl_movimentos_manuais.Domain.Interfaces.Respositories;
using apl_movimentos_manuais.Infra.Persistence;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.Context.Set<T>().AsParallel().AsEnumerable<T>();
        }

        #endregion
    }
}
