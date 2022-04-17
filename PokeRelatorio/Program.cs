using PokeRelatorio.Classes;
using PokeRelatorio.Utilitarios;
using System.Data;

string caminho = @"D:\Meus projetos\Estudos\Estudos Orientação Objeto\Novo\Arquivos";

string[] arquivosTxtPokemon = Directory.GetFiles(caminho, "*txt", SearchOption.AllDirectories);
List<string> colunas = ImportaArquivoPokemon.Colunas.Split("|").ToList();

List<Pokemon> pokemons = ImportaArquivoPokemon.ImportaTxtPokemon(arquivosTxtPokemon);
EscreverRelatorio.ExportaExcel(pokemons, colunas, caminho, "Pokémons", "Relatório Pokémon");

