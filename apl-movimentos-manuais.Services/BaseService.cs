using apl_movimentos_manuais.Domain.Interfaces.Respositories;
using apl_movimentos_manuais.Domain.Interfaces.Services;
using apl_movimentos_manuais.Infra.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apl_movimentos_manuais.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        #region Properties

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IBaseRepository<T> _baseRepository;

        #endregion

        #region Construtor

        public BaseService(IUnitOfWork unitOfWork, IBaseRepository<T> baseRepository)
        {
            _unitOfWork = unitOfWork;
            _baseRepository = baseRepository;
        }

        #endregion

        #region Methods

        //public virtual void Insert(T entity)
        //{
        //    _movimentoRepository.Insert(entity);
        //    _unitOfWork.Commit();
        //}

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _baseRepository.GetAll();
        }

        #endregion
    }
}
