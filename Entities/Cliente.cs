using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPai.Entities
{
    public class Cliente
    {
        public int Id{get;set;}
        public string Nome{get;set;}
        public string Telefone{get;set;} 
        public string QuadraELote{get;set;}
        public string Bairro{get;set;}

       //public  List<Servico> Servicos { get; set; }// lista de pedidos associados a um cliente.
    }
}