using System.Collections.Generic;
using System.Net;
using PurchaseAssistantWebApp.Models;

namespace PurchaseAssistantWebApp.Repository
{
    public interface IModelsSpecificationDataRepository
    {
        IEnumerable<ModelsSpecification> GetAllModelsSpecifications();

        HttpStatusCode AddNewModelsSpecification(ModelsSpecification newModelsSpecification);

        HttpStatusCode UpdateModelsSpecification(ModelsSpecification updatedModelsSpecification);

        HttpStatusCode DeleteModelsSpecification(long id);

    }
}
