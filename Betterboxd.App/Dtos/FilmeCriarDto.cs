using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betterboxd.App.Dtos
{
    public class FilmeCriarDto
    {
        public string? Titulo { get; set; }
        public string? Sinopse { get; set; }
        public string? Diretor { get; set; }
        public string? Genero { get; set; }
        public DateOnly DataLancamento { get; set; }
    }
}
