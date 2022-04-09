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
        private Guid Id { get; set; }
        private int DexNumber { get; set; }
        public string? Name { get; private set; }
        public string? Nature { get; private set; }
        public string? Ability { get; private set; }
        public string? PrimeiroTipo { get; private set; }
        public string? SegundoTipo { get; private set; }
        public int Nivel { get; set; }
        public List<Ataque> Ataques { get; private set; }

        public Pokemon(string name, string natureza, string ability, string primeiroTipo, string segundoTipo = "")
        {
            Id = Guid.NewGuid();
            DexNumber += 1;
            Name = name;
            Nature = natureza;
            Ability = ability;
            PrimeiroTipo = primeiroTipo;
            SegundoTipo = segundoTipo;
            Ataques = new List<Ataque>();
        }        

        public void DefineAtaques(Pokemon pokemon, string ataqueNome)
        {
            Ataque ataque = new Ataque(ataqueNome);
            pokemon.Ataques.Add(ataque);
        }        
    }
}
