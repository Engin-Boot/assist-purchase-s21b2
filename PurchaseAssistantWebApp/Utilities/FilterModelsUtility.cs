using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PurchaseAssistantWebApp.Models;

namespace PurchaseAssistantWebApp.Utilities
{
    public static class FilterModelsUtility
    {
        public static IEnumerable<ModelsSpecification> FilterById(long id, IEnumerable<ModelsSpecification> models)
        {
            return models.Where(model => model.Id == id);
        }

        public static IEnumerable<ModelsSpecification> FilterByProductName(string productName, IEnumerable<ModelsSpecification> models)
        {
            return models.Where(model => model.ProductName.Equals(productName));
        }

        public static IEnumerable<ModelsSpecification> FilterByProductKey(string productKey, IEnumerable<ModelsSpecification> models)
        {
            return models.Where(model => model.ProductKey.Equals(productKey));
        }

        public static IEnumerable<ModelsSpecification> FilterByPortability(bool isPortable, IEnumerable<ModelsSpecification> models)
        {
            return models.Where(model => model.Portable == isPortable);
        }

        public static IEnumerable<ModelsSpecification> FilterByCompactLevel(bool isCompact, IEnumerable<ModelsSpecification> models)
        {
            double maxScreenSize = isCompact ? 10.0 : Double.MaxValue;
            return models.Where(model => model.ScreenSize < maxScreenSize);
        }

        public static IEnumerable<ModelsSpecification> FilterByTouchScreenSupport(bool isTouchScreenRequired, IEnumerable<ModelsSpecification> models)
        {
            return models.Where(model => model.TouchScreenSupport == isTouchScreenRequired);
        }

        public static IEnumerable<ModelsSpecification> FilterByMonitorResolution(string resolution, IEnumerable<ModelsSpecification> models)
        {
            return models.Where(model => model.MonitorResolution.Equals(resolution));
        }

        public static IEnumerable<ModelsSpecification> FilterByBatterySupport(string batterySupport, IEnumerable<ModelsSpecification> models)
        {
            return models.Where(model => model.BatterySupport.Equals(batterySupport));
        }

        public static IEnumerable<ModelsSpecification> FilterByMultiPatientSupport(string multiPatientSupport, IEnumerable<ModelsSpecification> models)
        {
            return models.Where(model => model.MultiPatientSupport.Equals(multiPatientSupport));
        }
    }
}
