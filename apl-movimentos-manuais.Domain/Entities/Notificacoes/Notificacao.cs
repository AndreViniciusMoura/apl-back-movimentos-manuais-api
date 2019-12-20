using System;
using System.Collections.Generic;
using System.Text;

namespace apl_movimentos_manuais.Domain.Entities.Notificacoes
{
    public class Notificacao
    {
        #region Propriedades

        public string Mensagem { get; }

        #endregion

        #region Contrutor

        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }

        #endregion

        #region Metodos

        #endregion
    }
}
