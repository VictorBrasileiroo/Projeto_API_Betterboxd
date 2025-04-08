using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Betterboxd.Core.Entities
{
    public class AvaliacaoModel
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("IdUser")]
        public UserModel Usuario { get; set; }
        public int IdFilme { get; set; }
        [ForeignKey("IdFilme")]
        public FilmeModel Filme { get; set; }
        public decimal Nota { get; set; }
        public String? Comentario { get; set; }
        public DateOnly DataAvaliacao { get; set; }
    }
}
