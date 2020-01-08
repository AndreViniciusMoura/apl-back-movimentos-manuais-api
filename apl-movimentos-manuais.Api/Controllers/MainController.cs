using apl_movimentos_manuais.Domain.Entities.Notificacoes;
using apl_movimentos_manuais.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace apl_movimentos_manuais.Api.Controllers
{
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        #region Propriedades

        private readonly INotificadorService _notificadorService;

        #endregion

        #region Construtor

        public MainController(INotificadorService notificador)
        {
            _notificadorService = notificador;
        }

        #endregion

        #region Metodos

        protected bool OperacaoValida()
        {
            return !_notificadorService.TemNotificacao();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    Success = true,
                    Data = result
                });
            }

            return BadRequest(new
            {
                Success = false,
                Errors = _notificadorService.ObterNotificacoes().Select(n => n.Mensagem)
            });
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErrorModelInvalida(modelState);

            return CustomResponse();
        }

        protected void NotificarErrorModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                var errorMessage = erro.Exception is null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMessage);
            }
        }

        protected void NotificarErro(string mensagem)
        {
            _notificadorService.Handle(new Notificacao(mensagem));
        }

        #endregion
    }
}
