using PokeRelatorio.Classes;
using System.Data;

namespace PokeRelatorio.Utilitarios
{
    public class EscreverRelatorio
    {
        public static DataTable ImportaTxt(string caminho)
        {
            var arquivo = File.ReadAllLines(Path.Combine(caminho, "PokemonIniciais.txt")).ToList();
            DataTable dtArquivo = new();

            foreach (string coluna in arquivo.First().Split("|").ToList())
            {
                dtArquivo.Columns.Add(coluna);
            }

            for (int i = 1; i < arquivo.Count(); i++)
            {
                dtArquivo.Rows.Add(arquivo[i].Split("|"));
            }

            return dtArquivo;
        }
        public void ExportaExcel(Pokemon pokemon)
        {
            string caminho = @"D:\Meus projetos\Estudos\Estudos Orientação Objeto\Novo\Arquivos";

            DataTable dtArquivo = ImportaTxt(caminho);


        }
    }
}
