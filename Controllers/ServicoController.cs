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
        public IActionResult  Create([FromBody] Servicos servicos){ 
            var servico = new Servicos
            {
                ClientesId = servicos.ClientesId
            
            };
            _context.Servicos.Add(servico); 
            _context.SaveChanges();
            return Ok(servico);

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
        return Ok();
      }
      

    }
}