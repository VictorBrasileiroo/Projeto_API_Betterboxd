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
    public class FilmeCriarValidator : AbstractValidator<FilmeCriarDto>
    {
        public FilmeCriarValidator()
        {
            RuleFor(f => f.Titulo)
                .NotEmpty().WithMessage("O título é obrigatório")
                .Must(t => t != "string").WithMessage("Digite um título válido")
                .MinimumLength(2).WithMessage("O título deve possuir no mínimo 2 caracteres")
                .MaximumLength(100).WithMessage("O título deve possuir no máximo 100 caracteres");

            RuleFor(f => f.Sinopse)
                .NotEmpty().WithMessage("A sinopse é obrigatória")
                .Must(s => s != "string").WithMessage("Digite uma sinópse válida")
                .MaximumLength(500).WithMessage("A sinopse deve possuir no máximo 500 caracteres");

            RuleFor(f => f.DataLancamento)
                .NotEmpty().WithMessage("A data de lançamento é obrigatória")
                .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage("A data de lançamento não pode ser maior que a data atual.");

            RuleFor(f => f.Diretor)
                .NotEmpty().WithMessage("O nome do diretor é obrigatório")
                .Must(d => d != "string").WithMessage("Digite um diretor válida")
                .MaximumLength(100).WithMessage("O nome do diretor deve possuir no máximo 100 caracteres");

            RuleFor(f => f.Genero)
                .NotEmpty().WithMessage("O gênero é obrigatório")
                .Must(g => g != "string").WithMessage("Digite um gênero válido")
                .MaximumLength(50).WithMessage("O gênero deve possuir no máximo 50 caracteres");
        }
    }
}
