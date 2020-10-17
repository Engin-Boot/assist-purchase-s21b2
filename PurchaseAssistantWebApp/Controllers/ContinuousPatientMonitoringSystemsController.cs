using System;
using System.Net;
using System.Net.Http;
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
        public ActionResult Get([FromQuery] SearchFilter request)
        {
            return Ok(Utilities.FilterModelsUtility.ApplyAllFilters(_repository.GetAllModelsSpecifications(), request));
        }

    }
}
