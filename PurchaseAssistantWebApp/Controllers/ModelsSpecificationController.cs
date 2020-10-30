using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PurchaseAssistantWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsSpecificationController : ControllerBase
    {
        private readonly Repository.IModelsSpecificationDataRepository _repository;
        public ModelsSpecificationController(Repository.IModelsSpecificationDataRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<ModelsSpecificationController>
        [HttpGet]
        public IEnumerable<Models.ModelsSpecification> Get()
        {
            return _repository.GetAllModelsSpecifications();
        }

        // POST api/<ModelsSpecificationController>
        [HttpPost]
        public ActionResult Post([FromBody] Models.ModelsSpecification newModelSpecification)
        {
            try
            {
                _repository.AddNewModelsSpecification(newModelSpecification);
                return Ok("Model Added..");
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // PUT api/<ModelsSpecificationController>
        [HttpPut]
        public ActionResult Put([FromBody] Models.ModelsSpecification updatedModelSpecification)
        {
            try
            {
                _repository.UpdateModelsSpecification(updatedModelSpecification);
                return Ok("Model Updated..");
            }
            catch (ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (KeyNotFoundException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        // DELETE api/<ModelsSpecificationController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            try
            {
                _repository.DeleteModelsSpecification(id);
                return Ok("Model Deleted");
            }
            catch (KeyNotFoundException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
