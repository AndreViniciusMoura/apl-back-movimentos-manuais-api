using apl_movimentos_manuais.Domain.Entities.Notificacoes;
using System.Collections.Generic;

namespace apl_movimentos_manuais.Domain.Interfaces.Services
{
    public interface INotificadorService
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
