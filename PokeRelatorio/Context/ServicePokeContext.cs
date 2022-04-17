using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRelatorio.Context
{
    internal class ServicePokeContext
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PokeContext>(opt => opt.UseSqlServer("Server=localhost;Database=PokelistaDB;User Id=sa;Password=@Sql2019;"));
        }
    }
}
