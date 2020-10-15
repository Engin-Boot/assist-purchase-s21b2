using System;
using System.Collections.Generic;
using System.Net;
using PurchaseAssistantWebApp.Models;

namespace PurchaseAssistantWebApp.Repository
{
    public class ModelsSpecificationDataRepository : IModelsSpecificationDataRepository
    {
        public IEnumerable<ModelsSpecification> GetAllModelsSpecifications()
        {
            throw new NotImplementedException();
        }

        public ModelsSpecification GetModelsSpecificationById(long id)
        {
            throw new NotImplementedException();
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
