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
        public static List<Transacao> transacoes = new List<Transacao>();

        // GET
        /// <summary>
        /// Lista todas as transações
        /// </summary>
        [HttpGet]
        public ActionResult<ICollection<Transacao>> Get()
        {
            return transacoes;
        }

        // GET
        /// <summary>
        /// Lista uma transação pelo id
        /// </summary>
        [HttpGet("{id}")]
        public ActionResult<Transacao> Get(long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                return transacoes.Where(t => t.Id == id).FirstOrDefault();
            }
        }

        /// <summary>
        /// Lista as transações de um usuário
        /// </summary>
        [HttpGet("usuario/{id}")]
        public ActionResult<Transacao> GetByUser(long id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            else
            {
                return transacoes.Where(t => t.UsuarioId == id).FirstOrDefault();
            }
        }

        // POST
        /// <summary>
        /// Insere umas transação
        /// </summary>
        [HttpPost]
        public ActionResult<Transacao> Post([FromBody] Transacao transacao)
        {
            if (transacao.UsuarioId == 0 || transacao.Valor == 0 || transacao.Data == null || transacao.PedidoId == 0)
            {
                return BadRequest();
            }
            else
            {
                transacao.Id = transacoes.Count + 1;
                transacoes.Add(transacao);
                return transacao;
            }
        }
    }
}