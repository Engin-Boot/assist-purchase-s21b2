using System;
using System.Collections.Generic;
using System.Linq;
using PurchaseAssistantWebApp.Models;

namespace PurchaseAssistantWebApp.Utilities
{
    public static class FilterModelsUtility
    {
        public static IEnumerable<ModelsSpecification> ApplyAllFilters(IEnumerable<ModelsSpecification> allModels, SearchFilter searchRequest)
        {
            var filteredModels = FilterById(searchRequest.Id, allModels);
            filteredModels = FilterByProductName(searchRequest.ProductName, filteredModels);
            filteredModels = FilterByProductKey(searchRequest.ProductKey, filteredModels);
            filteredModels = FilterByPortability(searchRequest.Portability, filteredModels);
            filteredModels = FilterByBatterySupport(searchRequest.BatterySupport, filteredModels);
            filteredModels = FilterByMultiPatientSupport(searchRequest.MultiPatientSupport, filteredModels);
            filteredModels = FilterByTouchScreenSupport(searchRequest.TouchScreenSupport, filteredModels);

            return filteredModels;
        }
        public static IEnumerable<ModelsSpecification> FilterById(string id, IEnumerable<ModelsSpecification> models)
        {
            if (string.IsNullOrEmpty(id)) return models;

            var modelId = long.Parse(id);

            return models.Where(model => model.Id == modelId);
        }

        public static IEnumerable<ModelsSpecification> FilterByProductName(string productName, IEnumerable<ModelsSpecification> models)
        {
            if (string.IsNullOrEmpty(productName)) return models;

            return models.Where(model => model.ProductName.Equals(productName));
        }

        public static IEnumerable<ModelsSpecification> FilterByProductKey(string productKey, IEnumerable<ModelsSpecification> models)
        {
            if (string.IsNullOrEmpty(productKey)) return models;

            return models.Where(model => model.ProductKey.Equals(productKey));
        }

        public static IEnumerable<ModelsSpecification> FilterByPortability(string portability, IEnumerable<ModelsSpecification> models)
        {
            if (string.IsNullOrEmpty(portability)) return models;
            
            var isPortable = bool.Parse(portability);

            return models.Where(model => model.Portable == isPortable);
        }
        public static IEnumerable<ModelsSpecification> FilterByBatterySupport(string batterySupport, IEnumerable<ModelsSpecification> models)
        {
            if (string.IsNullOrEmpty(batterySupport)) return models;

            return models.Where(model => model.BatterySupport.Equals(batterySupport));
        }

        public static IEnumerable<ModelsSpecification> FilterByMultiPatientSupport(string multiPatientSupport, IEnumerable<ModelsSpecification> models)
        {
            if (string.IsNullOrEmpty(multiPatientSupport)) return models;

            return models.Where(model => model.MultiPatientSupport.Equals(multiPatientSupport));
        }
        public static IEnumerable<ModelsSpecification> FilterByTouchScreenSupport(string touchScreenSupport, IEnumerable<ModelsSpecification> models)
        {
            if (string.IsNullOrEmpty(touchScreenSupport)) return models;

            var isTouchScreenRequired = bool.Parse(touchScreenSupport);

            return models.Where(model => model.TouchScreenSupport == isTouchScreenRequired);
        }
    }
}
