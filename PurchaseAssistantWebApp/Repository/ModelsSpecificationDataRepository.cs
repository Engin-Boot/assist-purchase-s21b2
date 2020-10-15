using System;
using System.Collections.Generic;
using System.Net;
using PurchaseAssistantWebApp.Models;

namespace PurchaseAssistantWebApp.Repository
{
    public class ModelsSpecificationDataRepository : IModelsSpecificationDataRepository
    {
        List<ModelsSpecification> models = new List<ModelsSpecification>();
        public ModelsSpecificationDataRepository()
        {
            // Temporary model for sample test run
            models.Add(new ModelsSpecification { 
                Id = 00001, 
                BatterySupport = "5hr", 
                Description = "description", 
                MonitorResolution = "HD", 
                MultiPatientSupport = "available", 
                Portable = true, 
                Price = "400$", 
                ProductKey = "IMA01", 
                ProductName = "ProductA", 
                ScreenSize = 20.0, 
                TouchScreenSupport = true, 
                Weight = 10.5 });
        }
        public IEnumerable<ModelsSpecification> GetAllModelsSpecifications()
        {
            return models;
        }

        public HttpStatusCode AddNewModelsSpecification(ModelsSpecification newModelsSpecification)
        {
            throw new NotImplementedException();
        }

        public HttpStatusCode UpdateModelsSpecification(long id, ModelsSpecification updatedModelsSpecification)
        {
            throw new NotImplementedException();
        }

        public HttpStatusCode DeleteModelsSpecification(long id)
        {
            throw new NotImplementedException();
        }
    }
}
