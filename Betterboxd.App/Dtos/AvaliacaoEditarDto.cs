using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Betterboxd.App.Dtos
{
    public class AvaliacaoEditarDto
    {
        public decimal Nota { get; set; }
        public String? Comentario { get; set; }
        public DateOnly DataAvaliacao { get; set; }
    }
}
