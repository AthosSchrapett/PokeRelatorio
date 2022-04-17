using OfficeOpenXml;
using OfficeOpenXml.Style;
using PokeRelatorio.Classes;
using System.Data;
using System.Drawing;

namespace PokeRelatorio.Utilitarios
{
    public class EscreverRelatorio
    {
        public static void ExportaExcel(List<Pokemon> pokemons, string caminho, string nomeSheet, string nomeArquivo)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage pokemonPackage = new ExcelPackage();
            ExcelWorkbook pokemonWorkbook = pokemonPackage.Workbook;
            FileInfo fi = new FileInfo(Path.Combine(caminho, $"{nomeArquivo}.xlsx"));

            ExcelWorksheet pokemonWorksheet = pokemonWorkbook.Worksheets.Add(nomeSheet);

            pokemonWorksheet.Row(1).Style.Font.Bold = true;

            int i = 0;

            foreach (string coluna in ImportaArquivoPokemon.Colunas.Split("|").ToList())
            {
                i += 1;

                pokemonWorksheet.Cells[1, i].Value = coluna;
                pokemonWorksheet.Cells[1, i].Style.Font.Color.SetColor(color: Color.White);
                pokemonWorksheet.Cells[1, i].Style.Fill.SetBackground(color: Color.Crimson);

                for (int y = 0; y < pokemons.Count; y++)
                {
                    int index = y + 1;

                    pokemonWorksheet.Cells[index + 1, 1].Value = pokemons[y].Name;
                    pokemonWorksheet.Cells[index + 1, 2].Value = pokemons[y].FirstType;
                    pokemonWorksheet.Cells[index + 1, 3].Value = pokemons[y].SecondType;
                    pokemonWorksheet.Cells[index + 1, 4].Value = pokemons[y].Nature;
                    pokemonWorksheet.Cells[index + 1, 5].Value = pokemons[y].Ability;
                    pokemonWorksheet.Cells[index + 1, 6].Value = pokemons[y].Attacks[0].Nome;
                    pokemonWorksheet.Cells[index + 1, 7].Value = pokemons[y].Attacks[1].Nome;
                    pokemonWorksheet.Cells[index + 1, 8].Value = pokemons[y].Attacks[2].Nome;
                    pokemonWorksheet.Cells[index + 1, 9].Value = pokemons[y].Attacks[3].Nome;
                }
            }

            pokemonWorksheet.Cells.AutoFitColumns();

            pokemonPackage.SaveAs(fi);
        }
    }
}
