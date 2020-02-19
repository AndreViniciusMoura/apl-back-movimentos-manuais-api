using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace apl_movimentos_manuais.Api.ViewModels
{
    public class ProdutoViewModel
    {
        #region Properties

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CodProduto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string DesProduto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string StaStatus { get; set; }

        public virtual List<ProdutoCosifViewModel> ProdutosCosifViewModel { get; set; }

        #endregion

        #region Constructor

        public ProdutoViewModel()
        {
            ProdutosCosifViewModel = new List<ProdutoCosifViewModel>();
        }

        #endregion
    }
}
