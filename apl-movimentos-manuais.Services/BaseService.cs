using apl_movimentos_manuais.Domain.Entities;
using apl_movimentos_manuais.Domain.Entities.Notificacoes;
using apl_movimentos_manuais.Domain.Interfaces.Respositories;
using apl_movimentos_manuais.Domain.Interfaces.Services;
using apl_movimentos_manuais.Infra.Persistence;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apl_movimentos_manuais.Services
{
    public class BaseService
    {
        #region Properties

        private readonly INotificadorService _notificadorService;

        #endregion

        #region Construtor

        public BaseService(INotificadorService notificadorService)
        {
            _notificadorService = notificadorService;
        }

        #endregion

        #region Methods

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificadorService.Handle(new Notificacao(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }

        #endregion
    }
}
