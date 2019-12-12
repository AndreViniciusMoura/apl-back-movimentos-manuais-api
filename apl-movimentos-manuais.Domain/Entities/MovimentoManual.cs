using System;
using System.Collections.Generic;

namespace apl_movimentos_manuais.Domain.Entities
{
    public class MovimentoManual
    {
        #region Properties

        public decimal DataMes { get; set; }

        public decimal DataAno { get; set; }

        public decimal NumLancamento { get; set; }

        public string CodProduto { get; set; }

        public string CodCosif { get; set; }

        public string DesDescricao { get; set; }

        public DateTime DataMovimento { get; set; }

        public string CodUsuario { get; set; }

        public decimal Valor { get; set; }

        #region Foreign Keys

        public virtual ProdutoCosif Cod { get; set; }

        #endregion

        //public IList<ValidationFailure> IsValid()
        //{
        //    MovimentoManualValidator validation = new MovimentoManualValidator();
        //    var result = validation.Validate(this);

        //    return result.IsValid ? null : result.Errors;
        //}

        #endregion
    }
}
