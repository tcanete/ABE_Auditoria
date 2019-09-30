using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ABE_Auditoria.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABE_Auditoria.Controllers
{
    [Route("api/v1/public/[controller]")]
    [ApiController]
    public class TransacoesController : ControllerBase
    {
        // GET
        [HttpGet]
        public ActionResult<IEnumerable<Transacao>> Get()
        {
            return Startup.transacoes;
        }

        // GET
        [HttpGet("{id}")]
        public ActionResult<Transacao> Get(long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                return Startup.transacoes.Where(t => t.Id == id).FirstOrDefault();
            }
        }

        [HttpGet("usuario/{id}")]
        public ActionResult<Transacao> GetByUser(long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                return Startup.transacoes.Where(t => t.UsuarioId == id).FirstOrDefault();
            }
        }

        // POST
        [HttpPost]
        public ActionResult<Transacao> Post([FromBody] Transacao transacao)
        {

            if (transacao.UsuarioId == 0 || transacao.Valor == 0 || transacao.Data == null || transacao.PedidoId == 0)
            {
                return BadRequest();
            }
            else
            {
                transacao.Id = Startup.transacoes.Count + 1;
                Startup.transacoes.Add(transacao);
                return Ok(transacao);
            }
        }
    }
}