using apl_movimentos_manuais.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apl_movimentos_manuais.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAll();

        Task<Produto> GetById(Guid id);
    }
}
