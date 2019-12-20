using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace apl_movimentos_manuais.Domain.Interfaces.Services
{
    public interface IBaseService
    {
        void Notificar(ValidationResult validationResult);

        void Notificar(string mensagem);

        //bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity;
    }
}
