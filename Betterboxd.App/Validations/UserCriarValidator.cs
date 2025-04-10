using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betterboxd.App.Dtos;
using FluentValidation;

namespace Betterboxd.App.Validations
{
    public class UserCriarValidator : AbstractValidator<UserCriaDto>
    {
        public UserCriarValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório")
                .Must(n => n != "string").WithMessage("Digite um nome válido")
                .MaximumLength(256).WithMessage("O nome precisa ter no máximo 256 caracteres");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório")
                .Matches(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$").WithMessage("Digite um e-mail válido.");
        }
    }
}
