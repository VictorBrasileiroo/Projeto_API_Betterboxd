using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Betterboxd.Core.Entities
{
    public class FilmeModel
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Sinopse { get; set; }
        public string? Diretor { get; set; }
        public string? Genero { get; set; }
        public DateOnly DataLancamento { get; set; }
        public decimal NotaMedia { get; set; } = decimal.Zero;

        [JsonIgnore]
        public ICollection<AvaliacaoModel> Avaliacoes { get; set; }
    }
}
