using ConsultCurrency.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ConsultCurrency.Data
{
    public class ContextDb : DbContext
    {
        public IConfigurationRoot Configuration { get; set; }

        public string RetornaUrlConection()
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            string conexao = Configuration.GetConnectionString("db");
            return conexao;
        }
        public ContextDb(DbContextOptions<ContextDb> db) : base(db = new DbContextOptions<ContextDb>()) { }

        public DbSet<Cambio> Cambio { get; set; }
        public DbSet<Moeda> Moeda { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(RetornaUrlConection());
        }
    }
}
