using System.Collections.Generic;
using System.Net;
using PurchaseAssistantWebApp.Models;

namespace PurchaseAssistantWebApp.Repository
{
    public interface IModelsSpecificationDataRepository
    {
        IEnumerable<ModelsSpecification> GetAllModelsSpecifications();

        ModelsSpecification GetModelsSpecificationById(long id);

        HttpStatusCode AddNewModelsSpecification(ModelsSpecification newModelsSpecification);

        HttpStatusCode UpdateModelsSpecification(long id, ModelsSpecification updatedModelsSpecification);

        HttpStatusCode DeleteModelsSpecification(long id);

    }
}
