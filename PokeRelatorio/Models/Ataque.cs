using System.ComponentModel.DataAnnotations.Schema;

namespace PokeRelatorio.Classes
{
    public class Ataque
    {
        public Guid Id { get; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public int? Forca { get; set; }
        public Guid PokemonId { get; private set; }

        public Ataque(string nome, Guid pokemonId)
        {
            Id = Guid.NewGuid();
            PokemonId = pokemonId;
            Nome = nome;
        }
    }
}
