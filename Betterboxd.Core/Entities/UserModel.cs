using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Betterboxd.Core.Entities
{
    public class UserModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        [JsonIgnore]
        public ICollection<AvaliacaoModel> Avaliacoes { get; set; }
    }
}
