using System.Collections.Generic;
using System.Net;
using PurchaseAssistantWebApp.Database;
using PurchaseAssistantWebApp.Models;

namespace PurchaseAssistantWebApp.Repository
{
    public class ModelsSpecificationDataRepository : IModelsSpecificationDataRepository
    {
    
        protected readonly List<ModelsSpecification> MonitoringItems = new List<ModelsSpecification>();

        public ModelsSpecificationDataRepository()
        {
            var products = new ProductsGetter().Products;
            foreach (ModelsSpecification item in products)
                AddNewModelsSpecification(item);
        }
        /*List<ModelsSpecification> models = new List<ModelsSpecification>();
        public ModelsSpecificationDataRepository()
        {
            // Temporary model for sample test run
            modelsDb.Add(new ModelsSpecification { 
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
        }*/
        public IEnumerable<ModelsSpecification> GetAllModelsSpecifications()
        {
            return MonitoringItems;
        }

        public HttpStatusCode AddNewModelsSpecification(ModelsSpecification newModelsSpecification)
        {
            MonitoringItems.Add(newModelsSpecification);
            return HttpStatusCode.OK;
        }

        public HttpStatusCode UpdateModelsSpecification(long id, ModelsSpecification updatedModelsSpecification)
        {
            var currentProductId = updatedModelsSpecification.Id;
            for (var i = 0; i < MonitoringItems.Count; i++)
                if (MonitoringItems[i].Id == currentProductId)
                {
                    MonitoringItems.RemoveAt(i);
                    MonitoringItems.Add(updatedModelsSpecification);
                    var message = HttpStatusCode.Accepted;
                    return message;
                }

            return HttpStatusCode.OK;
        }

        public HttpStatusCode DeleteModelsSpecification(long id)
        {
            for (var i = 0; i < MonitoringItems.Count; i++)
                if (MonitoringItems[i].Id == id)
                {
                    var currentProduct = MonitoringItems[i];
                    MonitoringItems.RemoveAt(i);
                    var message = HttpStatusCode.Accepted;
                    return message;
                }
            return HttpStatusCode.OK;
        }
    }
}
