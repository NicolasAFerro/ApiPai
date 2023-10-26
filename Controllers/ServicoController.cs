
using System.IO;
using System.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiPai.Context;
using ApiPai.Entities;
namespace ApiPai.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServicoController : Controller
    {
     private readonly AppPaiContext _context;
        
     public ServicoController(AppPaiContext context){ 
        _context=context;
      }
      [HttpGet("{id}")] 
      public IActionResult ObterPorId(int id){ 
        var servico=_context.Servicos.Find(id); 
        if (servico == null)
                return NotFound();
            return Ok(servico);
      }
      [HttpPost] 
        public IActionResult  Create([FromBody] Servico servico, string nomeCliente, string quadraCliente){ 
           try{
              var cliente = _context.Clientes.FirstOrDefault(c => c.Nome == nomeCliente && c.QuadraELote == quadraCliente);
              servico.ClienteId = cliente.Id;
              
             /*  var novoServico = new Servico
              {
                ClienteId = servico.ClienteId,
                Valor = servico.Valor,
                Categoria = servico.Categoria,
                Data = servico.Data,
                Descricao = servico.Descricao
              }; */
              _context.Servicos.Add(servico);
              _context.SaveChanges();

              return Ok(servico);
            }
              catch (Exception ex){
                  return BadRequest($"Erro ao criar o serviço: {ex.Message}");
                  //Console.WriteLine(ex);
              }

        }
      [HttpDelete("{id}")] 
        public IActionResult Deletar(int id){ 
            var deletarServico = _context.Servicos.Find(id); 
            _context.Servicos.Remove(deletarServico);
            _context.SaveChanges();
            return Ok();
        }
      [HttpGet("ObterPorData")] 
        public IActionResult ObterPorData(DateTime data) { 
          var dataServico=_context.Servicos.Where(x=>x.Data.Date==data.Date);
          return Ok(dataServico);
        }

      [HttpGet("ObterPorNomeCadastrado")] 
       public IActionResult ObterPorNomeCadastrado(string nome, string quadraCliente) { 
        try{ 
          nome = nome.ToUpper();
          var cliente = _context.Clientes.FirstOrDefault(c => c.Nome == nome && c.QuadraELote == quadraCliente);
          if (cliente == null)
            return NotFound();
         
          var servicos = _context.Servicos.Where(s => s.ClienteId == cliente.Id).ToList();
          return Ok(servicos);
        }
        catch(Exception ex){ 
          return BadRequest($"Erro ao criar o serviço: {ex.Message}");
        }      
        
      }

      
      

    }
} 