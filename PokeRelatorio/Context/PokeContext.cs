using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PokeRelatorio.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeRelatorio.Context
{
    public class PokeContext : DbContext
    {
        public PokeContext(){}
        public PokeContext(DbContextOptions<PokeContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Ataque> Ataques { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Pokemon>(x => x.HasKey("Id"));
            builder.Entity<Ataque>(x => x.HasKey("Id"));
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=PokelistaDB;User Id=sa;Password=@Sql2019;");
            }
        }
    }
}
