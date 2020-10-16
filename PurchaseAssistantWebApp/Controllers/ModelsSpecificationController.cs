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
            _repository.AddNewModelsSpecification(newModelSpecification);
            return Ok();
        }

        // PUT api/<ModelsSpecificationController>/5
        [HttpPut("{id}")]
        public void Put(long id, [FromBody] Models.ModelsSpecification updatedModelSpecification)
        {
            _repository.UpdateModelsSpecification(id, updatedModelSpecification);
        }

        // DELETE api/<ModelsSpecificationController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            _repository.DeleteModelsSpecification(id);
        }
    }
}
