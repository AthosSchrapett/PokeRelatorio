using PokeRelatorio.Classes;
using PokeRelatorio.Utilitarios;
using System.Data;

string caminho = @"D:\Meus projetos\Estudos\Estudos Orientação Objeto\Novo\Arquivos";

DataTable dtArquivo = EscreverRelatorio.ImportaTxt(caminho);

List<Pokemon> pokemons = new();

foreach (DataRow linha in dtArquivo.Rows)
{
    Pokemon pokemon = new()
    {
        Name = linha["Name"].ToString(),
        Ability = linha["Ability"].ToString(),
        Nature = linha["Nature"].ToString(),
        FirstType = linha["Type1"].ToString(),
        SecondType = linha["Type2"].ToString()
    };

    pokemon.DefineAtaques(pokemon, linha["Attack1"].ToString());
    pokemon.DefineAtaques(pokemon, linha["Attack2"].ToString());
    pokemon.DefineAtaques(pokemon, linha["Attack3"].ToString());
    pokemon.DefineAtaques(pokemon, linha["Attack4"].ToString());

    pokemons.Add(pokemon);
}

EscreverRelatorio.ExportaExcel(pokemons, "Pokémons", dtArquivo.Columns, caminho);