using PokeRelatorio.Classes;
using PokeRelatorio.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRelatorio.Utilitarios
{
    public class ImportaArquivoPokemon
    {
        public static string Colunas { get; private set; }

        public static void ImportaTxtPokemon(string[] arquivosTxtPokemon, PokeContext context)
        {
            List<Pokemon> pokemons = new();

            foreach (string arquivo in arquivosTxtPokemon)
            {
                var arquivoTxt = File.ReadAllLines(Path.Combine(arquivo)).ToList();

                if (string.IsNullOrEmpty(Colunas))
                    Colunas = arquivoTxt.First();

                for (int i = 1; i < arquivoTxt.Count(); i++)
                {
                    List<string> listaDadosPokemon = arquivoTxt[i].Split("|").ToList();

                    Pokemon pokemon = new()
                    {
                        Name = listaDadosPokemon[0],
                        FirstType = listaDadosPokemon[1],
                        SecondType = listaDadosPokemon[2],
                        Nature = listaDadosPokemon[3],
                        Ability = listaDadosPokemon[4],
                    };

                    pokemon.DefineAtaques(listaDadosPokemon[5]);
                    pokemon.DefineAtaques(listaDadosPokemon[6]);
                    pokemon.DefineAtaques(listaDadosPokemon[7]);
                    pokemon.DefineAtaques(listaDadosPokemon[8]);

                    pokemon.DataCriacao(DateTime.Now);

                    context.Pokemons.Add(pokemon);
                    context.SaveChanges();
                }
            }           
        }
    }
}
