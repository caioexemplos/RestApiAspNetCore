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

            //if (valores.Length < 5000)
            //    return BadRequest();

            var ok= Ok(valores);

            return ok;
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

            //return CreatedAtAction(actionName: nameof(Post), product);
            return Ok(product);
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

        //[HttpGet]
        //public ActionResult ObterResultados()
        //{
        //    var valores = new string[] { "value1", "value2" };

        //    if (valores.Length < 5000)
        //        return CustomResponse();

        //    return CustomResponse(valores);
        //}
    }

    public abstract class MainController : ControllerBase
    {
        protected ActionResult CustomResponse(object result=null)
        {
            if(OperacaoValida())
            return Ok(new { 
                sucess=true,
                data=result
            });;

            return BadRequest(new
            {
                sucess = false,
                errors = ObterErros()
            });
        }

        public bool OperacaoValida()
        {
            //minhas validações
            return true;
        }

        protected string ObterErros()
        {
            return "";
        }
    }


    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
