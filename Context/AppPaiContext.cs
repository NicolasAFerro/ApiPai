using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPai.Entities;
using Microsoft.EntityFrameworkCore; 
using ApiPai.Controllers;


namespace ApiPai.Context
{
    public class AppPaiContext :DbContext
    {
        public AppPaiContext(DbContextOptions<AppPaiContext> options) : base(options){ 

        }
        public DbSet<Clientes> Clientes{get;set;}
        public DbSet<Servicos> Servicos{get;set;}
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurando um índice único na coluna Nome da entidade Clientes
            modelBuilder.Entity<Clientes>()
                .HasIndex(c => c.Nome)
                .IsUnique();

             // Configura a chave estrangeira para a entidade Servicos
           modelBuilder.Entity<Servicos>()
                .HasOne(s => s.Clientes) // Estabelece que um serviço pertence a um cliente
                .WithMany() // Não especifica a coleção no cliente, pois você não deseja passar todas as propriedades do cliente
                .HasForeignKey(s => s.ClientesId);
        }
     
        
    }
}