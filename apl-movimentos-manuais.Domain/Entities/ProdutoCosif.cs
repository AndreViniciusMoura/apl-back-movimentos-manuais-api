using System.Collections.Generic;

namespace apl_movimentos_manuais.Domain.Entities
{
    public class ProdutoCosif : Entity
    {
        #region Properties

        public string CodProduto { get; set; }

        public string CodCosif { get; set; }

        public string CodClassificacao { get; set; }

        public string StaStatus { get; set; }

        public virtual Produto CodProdutoNavigation { get; set; }

        public virtual ICollection<MovimentoManual> MovimentoManual { get; set; }

        #endregion

        #region Constructor

        public ProdutoCosif()
        {
            MovimentoManual = new HashSet<MovimentoManual>();
        }

        #endregion
    }
}
