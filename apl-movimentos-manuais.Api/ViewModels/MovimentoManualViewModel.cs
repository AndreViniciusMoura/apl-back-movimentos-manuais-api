using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apl_movimentos_manuais.Api.ViewModels
{
    public class MovimentoManualViewModel
    {
        #region Properties

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal DatMes { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal DatAno { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal NumLancamento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string CodProduto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(10, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string CodCosif { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string DesDescricao { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DatMovimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(4, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string CodUsuario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal ValValor { get; set; }

        #region Foreign Keys

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CodCodProduto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string CodCodProdutoNavigationDesProduto { get; set; }

        #endregion

        #endregion
    }
}
