using PokeRelatorio.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRelatorio.Interfaces
{
    public interface IPokemon
    {
        void DefineAtaques(Pokemon pokemon, string ataqueNome);
    }
}
