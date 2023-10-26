using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPai.Entities;
using Microsoft.EntityFrameworkCore; 
//using ApiPai.Controllers;


namespace ApiPai.Context
{
    public class AppPaiContext :DbContext
    {
        public AppPaiContext(DbContextOptions<AppPaiContext> options) : base(options){ 

        }
        public DbSet<Cliente> Clientes{get;set;}
        public DbSet<Servico> Servicos{get;set;}
       
        
    }
}