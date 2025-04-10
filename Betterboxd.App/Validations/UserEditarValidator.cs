using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Betterboxd.App.Dtos;
using FluentValidation;

namespace Betterboxd.App.Validations
{
    public class UserEditarValidator : AbstractValidator<UserEditarDto>
    {
        public UserEditarValidator()
        {
            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório")
                .MaximumLength(256).WithMessage("O nome precisa ter no máximo 256 caracteres");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório")
                .Must(email => email == "string" || Regex.IsMatch(email, @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$"))
                .WithMessage("Digite um e-mail válido.");
        }
    }
}
