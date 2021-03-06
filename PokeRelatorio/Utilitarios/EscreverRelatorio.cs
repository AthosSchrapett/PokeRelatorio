using OfficeOpenXml;
using OfficeOpenXml.Style;
using PokeRelatorio.Classes;
using PokeRelatorio.Context;
using System.Data;
using System.Drawing;

namespace PokeRelatorio.Utilitarios
{
    public class EscreverRelatorio
    {
        public static void ExportaExcel(PokeContext context, List<string> colunas, string caminho, string nomeSheet, string nomeArquivo)
        {
            List<Pokemon> pokemons = context.Pokemons.ToList();

            foreach (Pokemon pokemon in pokemons)
            {
                foreach (string ataque in context.Ataques.Where(x => x.PokemonId == pokemon.Id).Select(x => x.Nome).ToList())
                    pokemon.DefineAtaques(ataque);
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelPackage pokemonPackage = new ExcelPackage();
            ExcelWorkbook pokemonWorkbook = pokemonPackage.Workbook;
            FileInfo fi = new FileInfo(Path.Combine(caminho, $"{nomeArquivo}.xlsx"));

            ExcelWorksheet pokemonWorksheet = pokemonWorkbook.Worksheets.Add(nomeSheet);

            pokemonWorksheet.Row(1).Style.Font.Bold = true;

            int i = 0;

            foreach (string coluna in colunas)
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
