using apl_movimentos_manuais.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apl_movimentos_manuais.Domain.Interfaces.Services
{
    public interface IProdutoService: IDisposable
    {
        Task<IEnumerable<Produto>> GetAll();

        Task<Produto> GetById(Guid id);

        Task<bool> Adicionar(Produto produto);

        Task<bool> Atualizar(Produto produto);

        Task<bool> Remover(long id);
    }
}
