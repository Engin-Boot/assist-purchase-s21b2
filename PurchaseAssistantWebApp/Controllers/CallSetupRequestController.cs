using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PurchaseAssistantWebApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PurchaseAssistantWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CallSetupRequestController : ControllerBase
    {
        private readonly Repository.ICallSetupRequestDataRepository _repository;
        public CallSetupRequestController(Repository.ICallSetupRequestDataRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<CallSetupRequestController>
        [HttpGet]
        public IEnumerable<CallSetupRequest> Get()
        {
            return _repository.GetAllCallSetupRequest();
        }

        // POST api/<CallSetupRequestController>
        [HttpPost]
        public void Post([FromBody] CallSetupRequest newRequest)
        {
            _repository.AddNewCallSetupRequest(newRequest);
        }

        // PUT api/<CallSetupRequestController>
        [HttpPut]
        public void Put([FromBody] CallSetupRequest request)
        {
            _repository.UpdateCallSetupRequest(request);
        }

        // DELETE api/<CallSetupRequestController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _repository.DeleteCallSetupRequest(id);
        }
    }
}
