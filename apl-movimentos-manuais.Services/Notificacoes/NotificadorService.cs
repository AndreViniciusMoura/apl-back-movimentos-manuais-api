using apl_movimentos_manuais.Domain.Entities.Notificacoes;
using apl_movimentos_manuais.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;

namespace apl_movimentos_manuais.Services.Notificacoes
{
    public class NotificadorService : INotificadorService
    {
        #region Propriedades

        private List<Notificacao> _notificacoes;

        #endregion

        #region Construtor

        public NotificadorService()
        {
            _notificacoes = new List<Notificacao>();
        }

        #endregion

        #region Metodos

        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }

        #endregion
    }
}
