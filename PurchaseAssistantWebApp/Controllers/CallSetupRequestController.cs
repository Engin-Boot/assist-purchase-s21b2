using System;
using System.Collections.Generic;
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
        private readonly Repository.ISalesRepresentativeDataRepository _salesRepresentativeRepository;
        private readonly Utilities.IAlerter _alerter;
        public CallSetupRequestController(Repository.ICallSetupRequestDataRepository repository, 
            Repository.ISalesRepresentativeDataRepository salesRepresentativeRepository, 
            Utilities.IAlerter alerter)
        {
            _repository = repository;
            _salesRepresentativeRepository = salesRepresentativeRepository;
            _alerter = alerter;
        }

        // GET: api/<CallSetupRequestController>
        [HttpGet]
        public IEnumerable<CallSetupRequest> Get()
        {
            return _repository.GetAllCallSetupRequest();
        }

        // POST api/<CallSetupRequestController>
        [HttpPost]
        public ActionResult Post([FromBody] CallSetupRequest newRequest)
        {
            try
            {
                _repository.AddNewCallSetupRequest(newRequest);
                //_alerter.SendAlert(newRequest, _salesRepresentativeRepository.GetAllSalesRepresentativeByRegion(newRequest.Region));
                return Ok();
            }
            catch(ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT api/<CallSetupRequestController>
        [HttpPut]
        public ActionResult Put([FromBody] CallSetupRequest request)
        {
            try
            {
                _repository.UpdateCallSetupRequest(request);
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

        // DELETE api/<CallSetupRequestController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            try
            {
                _repository.DeleteCallSetupRequest(id);
                return Ok();
            }
            catch(KeyNotFoundException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
