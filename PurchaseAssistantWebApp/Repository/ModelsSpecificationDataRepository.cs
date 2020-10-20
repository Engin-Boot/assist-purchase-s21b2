using System;
using System.Collections.Generic;
using JetBrains.Annotations;
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

        [AssertionMethod]
        private void ValidateStringField(string name, string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(name, "Model specification required: " + name + " cannot be null or empty.");
            }
        }

        [AssertionMethod]
        private void ValidateModelSpecificationData(ModelsSpecification model)
        {
            ValidateStringField(nameof(model.ProductName), model.ProductName);
            ValidateStringField(nameof(model.ProductKey), model.ProductKey);
            ValidateStringField(nameof(model.Description), model.Description);
            ValidateStringField(nameof(model.Price), model.Price);
            ValidateStringField(nameof(model.MonitorResolution), model.MonitorResolution);
            ValidateStringField(nameof(model.BatterySupport), model.BatterySupport);
            ValidateStringField(nameof(model.MultiPatientSupport), model.MultiPatientSupport);
            ValidateStringField(nameof(model.BpCheck), model.BpCheck);
            ValidateStringField(nameof(model.HeartRateCheck), model.HeartRateCheck);
            ValidateStringField(nameof(model.EcgCheck), model.EcgCheck);
            ValidateStringField(nameof(model.SpO2Check), model.SpO2Check);
            ValidateStringField(nameof(model.TemperatureCheck), model.TemperatureCheck);
            ValidateStringField(nameof(model.CardiacOutputCheck), model.CardiacOutputCheck);
        }

        public IEnumerable<ModelsSpecification> GetAllModelsSpecifications()
        {
            return _monitoringItems;
        }

        public void AddNewModelsSpecification(ModelsSpecification newModelsSpecification)
        {
            ValidateModelSpecificationData(newModelsSpecification);

            foreach (ModelsSpecification model in _monitoringItems)
            {
                if (model.Id.Equals(newModelsSpecification.Id))
                {
                    throw new ArgumentException($"Model specification with {newModelsSpecification.Id} id already exists.", nameof(newModelsSpecification.Id));
                }
            }
            
            _monitoringItems.Add(newModelsSpecification);

        }

        public void UpdateModelsSpecification(ModelsSpecification updatedModelsSpecification)
        {
            ValidateModelSpecificationData(updatedModelsSpecification);

            var currentProductId = updatedModelsSpecification.Id;
            for (var i = 0; i < _monitoringItems.Count; i++)
                if (_monitoringItems[i].Id == currentProductId)
                {
                    _monitoringItems.RemoveAt(i);
                    _monitoringItems.Add(updatedModelsSpecification);
                    return;
                }

            throw new KeyNotFoundException($"Update operation failed. Model specification with { updatedModelsSpecification.Id } id does not exist.");
        }

        public void DeleteModelsSpecification(long id)
        {
            int totalModels = _monitoringItems.Count;
            for (var i = 0; i < totalModels; i++)
                if (_monitoringItems[i].Id == id)
                {
                    _monitoringItems.RemoveAt(i);
                    return;
                }
            throw new KeyNotFoundException($"Delete operation failed. Model specification with { id } id does not exist.");
        }
    }
}
