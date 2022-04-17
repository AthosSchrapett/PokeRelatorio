using PokeRelatorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRelatorio.Classes
{
    public class Pokemon : IPokemon
    {
        private Guid Id { get; }
        private int DexNumber { get; }
        public string Name { get; set; }
        public string Nature { get; set; }
        public string Ability { get; set; }
        public string FirstType { get; set; }
        public string SecondType { get; set; }
        public int Level { get; set; }
        public List<Ataque> Attacks { get; private set; }

        public Pokemon()
        {
            Id = Guid.NewGuid();
            DexNumber += 1;
            Attacks = new List<Ataque>();
        }        

        public void DefineAtaques(string ataqueNome)
        {
            Ataque ataque = new Ataque(ataqueNome);
            Attacks.Add(ataque);
        }        
    }
}
