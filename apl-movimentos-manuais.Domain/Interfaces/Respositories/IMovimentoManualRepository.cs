using apl_movimentos_manuais.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace apl_movimentos_manuais.Domain.Interfaces.Respositories
{
    public interface IMovimentoManualRepository : IBaseRepository<MovimentoManual>
    {
        IEnumerable<MovimentoManual> GetByMonthYear(int month, int year);
    }
}
