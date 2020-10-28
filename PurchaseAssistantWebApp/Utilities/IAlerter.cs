using PurchaseAssistantWebApp.Models;
using System.Collections.Generic;

namespace PurchaseAssistantWebApp.Utilities
{
    public interface IAlerter
    {
        public bool SendAlert(CallSetupRequest requestInfo, IEnumerable<SalesRepresentative> salesRepresentativesInCustomerRegion);
        public bool SendAlert(SalesRepresentative salesRepresentative, string customerEmail);
    }
}
