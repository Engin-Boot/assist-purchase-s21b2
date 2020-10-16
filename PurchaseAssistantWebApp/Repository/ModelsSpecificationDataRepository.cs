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
        
        public IEnumerable<ModelsSpecification> GetAllModelsSpecifications()
        {
            return MonitoringItems;
        }

        public HttpStatusCode AddNewModelsSpecification(ModelsSpecification newModelsSpecification)
        {
            MonitoringItems.Add(newModelsSpecification);
            return HttpStatusCode.OK;
        }

        public HttpStatusCode UpdateModelsSpecification(ModelsSpecification updatedModelsSpecification)
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
