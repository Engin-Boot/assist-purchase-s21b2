using System;
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
        public ActionResult Post([FromBody] SalesRepresentative newSalesRepresentative)
        {
            try
            {
                _repository.AddNewSalesRepresentative(newSalesRepresentative);
                return Ok();
            }
            catch(ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT api/<SalesRepresentativeController>
        [HttpPut]
        public ActionResult Put([FromBody] SalesRepresentative salesRepresentative)
        {
            try
            {
                _repository.UpdateSalesRepresentative(salesRepresentative);
                return Ok();
            }
            catch(ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch(KeyNotFoundException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // DELETE api/<SalesRepresentativeController>/SR001
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                _repository.DeleteSalesRepresentative(id);
                return Ok();
            }
            catch(KeyNotFoundException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
