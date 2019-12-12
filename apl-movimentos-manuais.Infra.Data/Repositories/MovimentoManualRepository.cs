using apl_movimentos_manuais.Domain.Entities;
using apl_movimentos_manuais.Domain.Interfaces.Respositories;
using apl_movimentos_manuais.Infra.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace apl_movimentos_manuais.Infra.Data.Repositories
{
    public class MovimentoManualRepository : MovimentoRepository<MovimentoManual>, IMovimentoManualRepository
    {
        #region Propriedades

        #endregion

        #region Construtor

        public MovimentoManualRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Metodos

        public IEnumerable<MovimentoManual> GetByMonthYear(int month, int year)
        {
            return _unitOfWork.Context.Set<MovimentoManual>().Include(i => i.Cod)
                                                                .ThenInclude(i => i.CodProdutoNavigation)
                                                            .AsNoTracking().Where(m => m.DataMes == month && m.DataAno == year);
        }

        #endregion

    }
}
