using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Betterboxd.Core.Entities;

namespace Betterboxd.App.Dtos
{
    public class AvaliacaoCriarDto
    {
        public int IdUser { get; set; }
        public int IdFilme { get; set; }
        public decimal Nota { get; set; }
        public String? Comentario { get; set; }
        public DateOnly DataAvaliacao { get; set; }
    }
}
