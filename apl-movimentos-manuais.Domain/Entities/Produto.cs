using System.Collections.Generic;

namespace apl_movimentos_manuais.Domain.Entities
{
    public class Produto : Entity
    {
        #region Properties

        public string CodProduto { get; set; }

        public string DesProduto { get; set; }

        public string StaStatus { get; set; }

        public virtual ICollection<ProdutoCosif> ProdutoCosif { get; set; }

        #endregion

        #region Constructor

        public Produto()
        {
            ProdutoCosif = new HashSet<ProdutoCosif>();
        }

        #endregion
    }
}
