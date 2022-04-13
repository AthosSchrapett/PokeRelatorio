using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRelatorio.Classes
{
    public class Ataque
    {
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public int? Forca { get; set; }

        public Ataque(string nome)
        {
            Nome = nome;
        }
    }
}
