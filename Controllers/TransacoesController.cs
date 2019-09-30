using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ABE_Auditoria.Controllers
{
    [Route("v1/public/[controller]")]
    [ApiController]
    public class TransacoesController : ControllerBase
    {
        // GET
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}