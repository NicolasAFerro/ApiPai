using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPai.Models;

namespace ApiPai.Entities
{
    public class Servicos
    {
        public int Id{get;set;}
        public int ClientesId{get;set;} 
        public double Valor{get;set;}
        public TiposServico Categoria{get;set;}
        public DateTime Data{get;set;}
        public string Descricao{get;set;}  
        public virtual Clientes Clientes { get; set; }
    }
}