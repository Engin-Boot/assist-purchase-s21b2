using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PurchaseAssistantWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseController : ControllerBase
    {
        // GET: api/<DatabaseController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET api/<DatabaseController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DatabaseController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DatabaseController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DatabaseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
