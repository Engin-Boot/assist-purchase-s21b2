using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PurchaseAssistantWebApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PurchaseAssistantWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesRepresentativeController : ControllerBase
    {
        private readonly Repository.ISalesRepresentativeDataRepository _repository;
        public SalesRepresentativeController(Repository.ISalesRepresentativeDataRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<SalesRepresentativeController>
        [HttpGet]
        public IEnumerable<SalesRepresentative> Get()
        {
            return _repository.GetAllSalesRepresentative();
        }

        // POST api/<SalesRepresentativeController>
        [HttpPost]
        public void Post([FromBody] SalesRepresentative newSalesRepresentative)
        {
            _repository.AddNewSalesRepresentative(newSalesRepresentative);
        }

        // PUT api/<SalesRepresentativeController>
        [HttpPut]
        public void Put([FromBody] SalesRepresentative salesRepresentative)
        {
            _repository.UpdateSalesRepresentative(salesRepresentative);
        }

        // DELETE api/<SalesRepresentativeController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _repository.DeleteSalesRepresentative(id);
        }
    }
}
