using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterRecipes.Domain.Models;


namespace MasterRecipes.Data.Context
{
    public class Context : DbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Receita> Receitas { get; set; }
        public DbSet<ReceitaIgrediente> ReceitaIgredientes { get; set; }
        public DbSet<ReceitaImagem> ReceitaImagens { get; set; }
        public DbSet<ReceitaTags> ReceitaTags { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receita>()
     .Metadata.SetNavigationAccessMode(PropertyAccessMode.Field);
        }
    }
}
