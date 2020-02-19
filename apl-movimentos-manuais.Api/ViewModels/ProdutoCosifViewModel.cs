using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apl_movimentos_manuais.Api.ViewModels
{
    public class ProdutoCosifViewModel
    {
        #region Properties

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CodProduto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CodCosif { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CodClassificacao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string StaStatus { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CodProdutoNavigationDesProduto { get; set; }

        public virtual List<MovimentoManualViewModel> MovimentosManuaisViewModel { get; set; }

        #endregion

        #region Constructor

        public ProdutoCosifViewModel()
        {
            MovimentosManuaisViewModel = new List<MovimentoManualViewModel>();
        }

        #endregion
    }
}
