using System;
using System.Collections.Generic;
using System.Linq;
using PurchaseAssistantWebApp.Models;

namespace PurchaseAssistantWebApp.Utilities
{
    public static class FilterModelsUtility
    {
        public static IEnumerable<ModelsSpecification> ApplyAllFilters(IEnumerable<ModelsSpecification> allModels, SearchQuery searchRequest)
        {
            var filteredModels = FilterById(searchRequest.Id, allModels);
            filteredModels = FilterByProductName(searchRequest.ProductName, filteredModels);
            filteredModels = FilterByProductKey(searchRequest.ProductKey, filteredModels);
            filteredModels = FilterByPortability(searchRequest.Portability, filteredModels);
            filteredModels = FilterByBatterySupport(searchRequest.BatterySupport, filteredModels);
            filteredModels = FilterByMultiPatientSupport(searchRequest.MultiPatientSupport, filteredModels);
            filteredModels = FilterByTouchScreenSupport(searchRequest.TouchScreenSupport, filteredModels);
            
            filteredModels = FilterByBpCheck(searchRequest.BpCheck, filteredModels);
            filteredModels = FilterByHeartRateCheck(searchRequest.HeartRateCheck, filteredModels);
            filteredModels = FilterByEcgCheck(searchRequest.EcgCheck, filteredModels);
            filteredModels = FilterBySpO2Check(searchRequest.SpO2Check, filteredModels);
            filteredModels = FilterByTemperatureCheck(searchRequest.TemperatureCheck, filteredModels);
            filteredModels = FilterByCardiacOutputCheck(searchRequest.CardiacOutputCheck, filteredModels);

            return filteredModels;
        }
        public static IEnumerable<ModelsSpecification> FilterById(string id, IEnumerable<ModelsSpecification> models)
        {
            if (string.IsNullOrEmpty(id)) return models;

            if (long.TryParse(id, out var modelId))
            {
                return models.Where(model => model.Id == modelId);
            }
            else
            {
                throw new ArgumentException("Query Argument 'id' is invalid. Id must be a long number.");
            }
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
            
            if(bool.TryParse(portability, out var isPortable))
            {
                return models.Where(model => model.Portable == isPortable);
            }
            else
            {
                throw new ArgumentException("Query Argument 'portability' is invalid. It must be a boolean value (either true or false).");
            }    
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

            if (bool.TryParse(touchScreenSupport, out var isTouchScreenRequired))
            {
                return models.Where(model => model.TouchScreenSupport == isTouchScreenRequired);
            }
            else
            {
                throw new ArgumentException("Query Argument 'touchScreenSupport' is invalid. It must be a valid boolean value (either true or false).");
            }
        }
        
        // clinical
        public static IEnumerable<ModelsSpecification> FilterByBpCheck(string bpCheck, IEnumerable<ModelsSpecification> models)
        {
            if (string.IsNullOrEmpty(bpCheck)) return models;

            return models.Where(model => model.BpCheck.Equals(bpCheck));
        }

        public static IEnumerable<ModelsSpecification> FilterByHeartRateCheck(string heartRateCheck, IEnumerable<ModelsSpecification> models)
        {
            if (string.IsNullOrEmpty(heartRateCheck)) return models;

            return models.Where(model => model.HeartRateCheck.Equals(heartRateCheck));
        }

        public static IEnumerable<ModelsSpecification> FilterByEcgCheck(string ecgCheck, IEnumerable<ModelsSpecification> models)
        {
            if (string.IsNullOrEmpty(ecgCheck)) return models;

            return models.Where(model => model.EcgCheck.Equals(ecgCheck));
        }

        public static IEnumerable<ModelsSpecification> FilterBySpO2Check(string spO2Check, IEnumerable<ModelsSpecification> models)
        {
            if (string.IsNullOrEmpty(spO2Check)) return models;

            return models.Where(model => model.SpO2Check.Equals(spO2Check));
        }

        public static IEnumerable<ModelsSpecification> FilterByTemperatureCheck(string temperatureCheck, IEnumerable<ModelsSpecification> models)
        {
            if (string.IsNullOrEmpty(temperatureCheck)) return models;

            return models.Where(model => model.TemperatureCheck.Equals(temperatureCheck));
        }

        public static IEnumerable<ModelsSpecification> FilterByCardiacOutputCheck(string cardiacOutputCheck, IEnumerable<ModelsSpecification> models)
        {
            if (string.IsNullOrEmpty(cardiacOutputCheck)) return models;

            return models.Where(model => model.CardiacOutputCheck.Equals(cardiacOutputCheck));
        }
        
    }
}
