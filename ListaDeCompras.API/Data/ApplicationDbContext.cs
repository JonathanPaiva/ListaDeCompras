using ListaDeCompras.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ListaDeCompras.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Setor> Setores {get; set;}
        public DbSet<Item> Itens { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        //Configurçaões Padrões para Entidades no Banco de Dados
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Ignore<Entidade>();

            #region Item
                builder.Entity<Item>().Property(i => i.Nome).IsRequired();
            #endregion
        }

        //Configurações padrões para todos os tipos de campos de acordo com o que foi estipulado
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(100);
        }
    }
}
