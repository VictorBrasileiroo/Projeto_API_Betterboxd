using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betterboxd.App.Dtos;
using Betterboxd.Core.Entities;
using FluentValidation;

namespace Betterboxd.App.Validations
{
    public class FilmeEditarValidator : AbstractValidator<FilmeEditarDto>
    {
        public FilmeEditarValidator()
        {
            RuleFor(f => f.Titulo)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("O título é obrigatório")
                .MinimumLength(2).WithMessage("O título deve possuir no mínimo 2 caracteres")
                .MaximumLength(100).WithMessage("O título deve possuir no máximo 100 caracteres")
                .When(f => f.Titulo != null);

            RuleFor(f => f.DataLancamento)
                .NotEmpty().WithMessage("A data de lançamento é obrigatória")
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage("A data de lançamento não pode ser maior que a data atual.");

            RuleFor(f => f.Genero)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("O gênero é obrigatório")
                .MinimumLength(2).WithMessage("O gênero deve possuir no mínimo 2 caracteres")
                .MaximumLength(50).WithMessage("O gênero deve possuir no máximo 50 caracteres")
                .When(f => f.Genero != null);

            RuleFor(f => f.Diretor)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("O diretor é obrigatório")
                .MinimumLength(2).WithMessage("O nome do diretor deve possuir no mínimo 2 caracteres")
                .MaximumLength(100).WithMessage("O nome do diretor deve possuir no máximo 100 caracteres")
                .When(f => f.Diretor != null);

            RuleFor(f => f.Sinopse)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("A sinopse é obrigatória")
                .MaximumLength(1000).WithMessage("A sinopse deve possuir no máximo 1000 caracteres")
                .When(f => f.Sinopse != null);

        }
    }
}
