using PokeRelatorio.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRelatorio.Classes
{
    public class Pokemon : IPokemon
    {
        public Guid Id { get; }
        public DateTime CreatedAt { get; private set; }
        public int? DexNumber { get; }
        public string Name { get; set; }
        public string Nature { get; set; }
        public string Ability { get; set; }
        public string FirstType { get; set; }
        public string? SecondType { get; set; }
        public int? Level { get; set; }
        public List<Ataque>? Attacks { get; private set; }

        public Pokemon()
        {
            Id = Guid.NewGuid();
            Attacks = new List<Ataque>();
        }        

        public void DefineAtaques(string ataqueNome)
        {
            Ataque ataque = new Ataque(ataqueNome, Id);
            if(Attacks.Count < 4)
                Attacks.Add(ataque);
        }

        public void DataCriacao(DateTime createdAt)
        {
            CreatedAt = createdAt;
        }
    }
}
