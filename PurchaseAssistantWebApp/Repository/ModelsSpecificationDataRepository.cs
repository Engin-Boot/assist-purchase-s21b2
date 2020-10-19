using System.Collections.Generic;
using System.Net;
using PurchaseAssistantWebApp.Database;
using PurchaseAssistantWebApp.Models;

namespace PurchaseAssistantWebApp.Repository
{
    public class ModelsSpecificationDataRepository : IModelsSpecificationDataRepository
    {
    
        private readonly List<ModelsSpecification> _monitoringItems = new List<ModelsSpecification>();

        public ModelsSpecificationDataRepository()
        {
            var products = new ProductsGetter().Products;
            foreach (ModelsSpecification item in products)
                AddNewModelsSpecification(item);
        }
        
        public IEnumerable<ModelsSpecification> GetAllModelsSpecifications()
        {
            return _monitoringItems;
        }

        public HttpStatusCode AddNewModelsSpecification(ModelsSpecification newModelsSpecification)
        {
            _monitoringItems.Add(newModelsSpecification);
            return HttpStatusCode.OK;
        }

        public HttpStatusCode UpdateModelsSpecification(ModelsSpecification updatedModelsSpecification)
        {
            var currentProductId = updatedModelsSpecification.Id;
            for (var i = 0; i < _monitoringItems.Count; i++)
                if (_monitoringItems[i].Id == currentProductId)
                {
                    _monitoringItems.RemoveAt(i);
                    _monitoringItems.Add(updatedModelsSpecification);
                    var message = HttpStatusCode.Accepted;
                    return message;
                }

            return HttpStatusCode.OK;
        }

        public HttpStatusCode DeleteModelsSpecification(long id)
        {
            for (var i = 0; i < _monitoringItems.Count; i++)
                if (_monitoringItems[i].Id == id)
                {
                    _monitoringItems.RemoveAt(i);
                    var message = HttpStatusCode.Accepted;
                    return message;
                }
            return HttpStatusCode.OK;
        }
    }
}
