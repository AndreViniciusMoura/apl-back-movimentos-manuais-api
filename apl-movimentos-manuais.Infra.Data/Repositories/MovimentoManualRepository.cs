using apl_movimentos_manuais.Domain.Entities;
using apl_movimentos_manuais.Domain.Interfaces.Respositories;
using apl_movimentos_manuais.Infra.Persistence;
using apl_movimentos_manuais.Infra.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace apl_movimentos_manuais.Infra.Data.Repositories
{
    public class MovimentoManualRepository : BaseRepository<MovimentoManual>, IMovimentoManualRepository
    {
        #region Propriedades

        private readonly MovimentosManuaisContext _context;

        #endregion

        #region Construtor

        public MovimentoManualRepository(MovimentosManuaisContext context) : base(context)
        {
            _context = context;
        }

        #endregion

        #region Metodos

        public IEnumerable<MovimentoManual> GetByMonthYear(int month, int year)
        {
            return _context.Set<MovimentoManual>().Include(i => i.Cod)
                                                      .ThenInclude(i => i.CodProdutoNavigation)
                                                  .AsNoTracking().Where(m => m.DataMes == month && m.DataAno == year);
        }

        #endregion

    }
}
