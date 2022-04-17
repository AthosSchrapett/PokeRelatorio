using Microsoft.Extensions.DependencyInjection;
using PokeRelatorio.Classes;
using PokeRelatorio.Context;
using PokeRelatorio.Utilitarios;
using System.Data;

string caminho = @"D:\Meus projetos\Estudos\Estudos Orientação Objeto\Novo\Arquivos";

var collection = new ServiceCollection();
ServicePokeContext.ConfigureServices(collection);
var serviceProvider = collection.BuildServiceProvider();
var context = serviceProvider.GetService<PokeContext>();

string[] arquivosTxtPokemon = Directory.GetFiles(caminho, "*txt", SearchOption.AllDirectories);

ImportaArquivoPokemon.ImportaTxtPokemon(arquivosTxtPokemon, context);

List<string> colunas = ImportaArquivoPokemon.Colunas.Split("|").ToList();

EscreverRelatorio.ExportaExcel(context, colunas, caminho, "Pokémons", "Relatório Pokémon");

