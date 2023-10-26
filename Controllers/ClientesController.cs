using System.Threading.Tasks.Dataflow;
using System.Net.Http;
using System.Net.Cache;
using System.Reflection.Metadata;
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
    public class ClientesController : ControllerBase
    {
      private readonly AppPaiContext _context;

      public ClientesController(AppPaiContext context){ 
        _context=context;
      }
      [HttpPost] 
      public IActionResult Create([FromBody] Clientes cliente){ 
        try{  
          var clienteExistente = _context.Clientes.FirstOrDefault(c => c.Nome == cliente.Nome);
          var quadraCliente = _context.Clientes.FirstOrDefault(x=>x.QuadraELote==cliente.QuadraELote);
          if ((clienteExistente != null)&&(quadraCliente != null)){
              return Conflict ("Cliente já existe");
          }
          else{  
              _context.Add(cliente); 
              _context.SaveChanges();
              return CreatedAtAction(nameof(ObterPorID), new{id=cliente.Id},cliente);
          }
        }catch(Exception ex){ 
          return BadRequest($"Erro ao criar o serviço: {ex.Message}");
        }
       
       
        
      }
      [ HttpGet("{id}")]
      public IActionResult ObterPorID(int id){ 
        var cliente=_context.Clientes.Find(id); 
        if (cliente == null)
                return NotFound();
            return Ok(cliente);
      }
      [HttpGet("ObterPorNome")] 
      public IActionResult ObterPorNome(string nome){ 
        var cliente=_context.Clientes.Where(x=>x.Nome.Contains(nome));
        return Ok(cliente);     
      }

      [HttpGet("ObterPorQuadraLote")]
      
      public IActionResult ObterPorQuadraLote(string quadra) { 
        var cliente = _context.Clientes.Where(x=>x.QuadraELote.Contains(quadra));
        return Ok(cliente);
      }

      [HttpPut("{nome}")]

      public IActionResult Atualizar(string nome,Clientes cliente){ 
        if (cliente == null) {
            return BadRequest("Dados de cliente inválidos");
        }
        var atualizarClientes = _context.Clientes.FirstOrDefault(x=>x.Nome==nome); 
        if(cliente == null)
            return NotFound();
        atualizarClientes.Nome=cliente.Nome; 
        atualizarClientes.Telefone=  cliente.Telefone; 
        atualizarClientes.QuadraELote=cliente.QuadraELote; 
        atualizarClientes.Bairro=cliente.Bairro; 

        _context.Clientes.Update(atualizarClientes);
        _context.SaveChanges(); 

        return Ok(atualizarClientes);
      }
      [HttpDelete("{nome}")]
        public IActionResult Deletar(string nome){ 
            var deletarCliente = _context.Clientes.FirstOrDefault(x=>x.Nome==nome); 
            if(deletarCliente==null)
                return NotFound();
            _context.Clientes.Remove(deletarCliente);
            _context.SaveChanges();
            return Ok();
        }
    }
}