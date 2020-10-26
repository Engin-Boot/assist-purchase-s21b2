using System.Collections.Generic;
using PurchaseAssistantWebApp.Models;

namespace PurchaseAssistantWebApp.Repository
{
    public interface IModelsSpecificationDataRepository
    {
        IEnumerable<ModelsSpecification> GetAllModelsSpecifications();

        void AddNewModelsSpecification(ModelsSpecification newModelsSpecification);

        void UpdateModelsSpecification(ModelsSpecification updatedModelsSpecification);

        void DeleteModelsSpecification(long id);

        ModelsSpecification GetModel(long id);
    }
}
