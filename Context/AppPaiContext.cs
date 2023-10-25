using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPai.Entities;
using Microsoft.EntityFrameworkCore; 


namespace ApiPai.Context
{
    public class AppPaiContext :DbContext
    {
        public AppPaiContext(DbContextOptions<AppPaiContext> options) : base(options){ 

        }
        public DbSet<Clientes> Clientes{get;set;}
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurando um índice único na coluna Nome da entidade Clientes
            modelBuilder.Entity<Clientes>()
                .HasIndex(c => c.Nome)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}