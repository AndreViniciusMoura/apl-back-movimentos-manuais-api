using apl_movimentos_manuais.Domain.Interfaces.Respositories;
using apl_movimentos_manuais.Infra.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace apl_movimentos_manuais.Infra.Data.Repositories
{
    public class MovimentoRepository<T> : IMovimentoRepository<T> where T : class
    {
        #region Properties

        protected readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Construtor

        public MovimentoRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Methods

        public void Insert(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.Context.Set<T>().AsParallel().AsEnumerable<T>();
        }

        #endregion
    }
}
