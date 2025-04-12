using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betterboxd.App.Dtos;
using Betterboxd.Core.Interfaces;
using FluentValidation;

namespace Betterboxd.App.Validations
{
    public class AvaliacaoEditarValidator : AbstractValidator<AvaliacaoEditarDto>
    {
        public AvaliacaoEditarValidator()
        {

            RuleFor(a => a.Nota)
                .InclusiveBetween(0, 5).WithMessage("A nota precisa estar entre 0 e 5");

            RuleFor(a => a.Comentario)
                .NotEmpty().WithMessage("O comentário é obrigatório")
                .MaximumLength(500).WithMessage("O comentário deve possuir no máximo 500 caracteres");

            RuleFor(f => f.DataAvaliacao)
                .NotEmpty().WithMessage("A data de avaliação é obrigatória")
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage("A data de avaliaçãos não pode ser maior que a data atual.");
        }
    }
}
