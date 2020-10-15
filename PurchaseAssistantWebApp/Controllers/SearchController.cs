using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PurchaseAssistantWebApp.Models;
using PurchaseAssistantWebApp.Utilities;

namespace PurchaseAssistantWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly Repository.IModelsSpecificationDataRepository _repository;

        public SearchController(Repository.IModelsSpecificationDataRepository repository)
        {
            _repository = repository;
        }

        // Returns list of all monitors
        [HttpGet("ContinuousPatientMonitoringSystem")]
        public IEnumerable<ModelsSpecification> GetAllModels()
        {
            return _repository.GetAllModelsSpecifications();
        }

        [HttpGet("ContinuousPatientMonitoringSystem/id/{id}")]
        public IEnumerable<ModelsSpecification> GetModelsById(long id)
        {
            return FilterModelsUtility.FilterById(id, _repository.GetAllModelsSpecifications());
        }

        [HttpGet("ContinuousPatientMonitoringSystem/productName/{productName}")]
        public IEnumerable<ModelsSpecification> GetModelsByProductName(string productName)
        {
            return FilterModelsUtility.FilterByProductName(productName, _repository.GetAllModelsSpecifications());
        }

        [HttpGet("ContinuousPatientMonitoringSystem/productKey/{productKey}")]
        public IEnumerable<ModelsSpecification> GetModelsByProductKey(string productKey)
        {
            return FilterModelsUtility.FilterByProductKey(productKey, _repository.GetAllModelsSpecifications());
        }

        [HttpGet("ContinuousPatientMonitoringSystem/isPortable/{isPortable}")]
        public IEnumerable<ModelsSpecification> GetModelsByPortability(bool isPortable)
        {
            return FilterModelsUtility.FilterByPortability(isPortable, _repository.GetAllModelsSpecifications());
        }

        [HttpGet("ContinuousPatientMonitoringSystem/compact/{isCompact}")]
        public IEnumerable<ModelsSpecification> GetModelsByCompactLevel(bool isCompact)
        {
            return FilterModelsUtility.FilterByCompactLevel(isCompact, _repository.GetAllModelsSpecifications());
        }

        [HttpGet("ContinuousPatientMonitoringSystem/isTouchScreenRequired/{isTouchScreenRequired}")]
        public IEnumerable<ModelsSpecification> GetModelsByTouchScreenSupport(bool isTouchScreenRequired)
        {
            return FilterModelsUtility.FilterByTouchScreenSupport(isTouchScreenRequired, _repository.GetAllModelsSpecifications());
        }

        [HttpGet("ContinuousPatientMonitoringSystem/resolution/{resolution}")]
        public IEnumerable<ModelsSpecification> GetModelsByMonitorResolution(string resolution)
        {
            return FilterModelsUtility.FilterByMonitorResolution(resolution, _repository.GetAllModelsSpecifications());
        }

        [HttpGet("ContinuousPatientMonitoringSystem/batterySupport/{batterySupport}")]
        public IEnumerable<ModelsSpecification> GetModelsByBatterySupport(string batterySupport)
        {
            return FilterModelsUtility.FilterByBatterySupport(batterySupport, _repository.GetAllModelsSpecifications());
        }

        [HttpGet("ContinuousPatientMonitoringSystem/multiPatientSupport/{multiPatientSupport}")]
        public IEnumerable<ModelsSpecification> GetModelsByMultiPatientSupport(string multiPatientSupport)
        {
            return FilterModelsUtility.FilterByMultiPatientSupport(multiPatientSupport, _repository.GetAllModelsSpecifications());
        }

    }
}
