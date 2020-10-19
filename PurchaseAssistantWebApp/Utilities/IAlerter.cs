using PurchaseAssistantWebApp.Models;
using System.Collections.Generic;

namespace PurchaseAssistantWebApp.Utilities
{
    public interface IAlerter
    {
        public bool SendAlert(Models.CallSetupRequest requestInfo, IEnumerable<SalesRepresentative> salesRepresentativesInCustomerRegion);
    }
}
