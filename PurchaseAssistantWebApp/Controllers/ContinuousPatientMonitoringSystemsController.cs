using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PurchaseAssistantWebApp.Models;

namespace PurchaseAssistantWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContinuousPatientMonitoringSystemsController : ControllerBase
    {
        private readonly Repository.IModelsSpecificationDataRepository _repository;

        public ContinuousPatientMonitoringSystemsController(Repository.IModelsSpecificationDataRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult Get([FromQuery] SearchQuery request)
        {
            try
            {
                IEnumerable<ModelsSpecification> filteredModelResult = Utilities.FilterModelsUtility.ApplyAllFilters(_repository.GetAllModelsSpecifications(), request);
                return Ok(filteredModelResult);
            }
            catch(ArgumentException exception)
            {
                return BadRequest(exception.Message);
            }
        }

    }
}
