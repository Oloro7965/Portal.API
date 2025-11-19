using FluentValidation;
using Portal.Application.Commands.CreateUserCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Application.Validators
{
    public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.NomeCompleto)
            .NotEmpty().WithMessage("O nome é obrigatório.");

            RuleFor(x => x.email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("Email inválido.");
        }
    }
}
