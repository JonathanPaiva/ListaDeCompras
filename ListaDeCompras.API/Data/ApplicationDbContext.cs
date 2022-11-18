using ListaDeCompras.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDeCompras.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Ambiente> Ambientes {get; set;}
        public DbSet<Item> Itens { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }

        //Configurçaões Padrões para Entidades no Banco de Dados
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Item
                builder.Entity<Item>()
                    .Property(i => i.Nome)
                    .IsRequired();
            #endregion

            #region Ambiente
                builder.Entity<Ambiente>()
                    .HasMany(i => i.Itens)
                    .WithOne(a => a.Ambiente)
                    .OnDelete(DeleteBehavior.Restrict);
            #endregion
        }

        //Configurações padrões para todos os tipos de campos de acordo com o que foi estipulado
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(100);
        }
    }
}
