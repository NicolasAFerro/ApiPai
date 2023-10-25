using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPai.Entities
{
    public class Clientes
    {
        public int Id{get;set;}
        public string Nome{get;set;}
        public string Telefone{get;set;} 
        public string QuadraELote{get;set;}
        public string Bairro{get;set;}
    }
}