using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace MinhaAPICore.Controllers
{
    [Route("api/[controller]")]

    public class ValuesController : MainController
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var valores = new string[] { "value1", "value2" };

            if (valores.Length < 5000)
                return BadRequest();

            return Ok(valores);
        }
        [HttpGet]
        public ActionResult GetValores()
        {
            var valores = new string[] { "value1", "value2" };

            if (valores.Length < 5000)
                return BadRequest();

            return Ok(valores);
        }


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPost]
        [ProducesResponseType(typeof(Produto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post(Produto product)
        {
            if (product.Id == 0)
                return BadRequest();
            //add no banco

            return CreatedAtAction(actionName: nameof(Post), product);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromRoute]int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete([FromHeader]int id)
        {
        }
    }

    public abstract class MainController : ControllerBase
    {
        protected ActionResult CustomResponse(object result=null)
        {
            if(OperacaoValida())
            return Ok();

            return BadRequest();
        }

        public bool OperacaoValida()
        {
            return true;
        }
    }


    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
