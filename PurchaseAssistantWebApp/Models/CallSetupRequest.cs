using System.Collections.Generic;

namespace PurchaseAssistantWebApp.Models
{
    public class CallSetupRequest
    {
        public long Id { get; set; }

        public string PointOfContactName { get; set; }

        public string Organisation { get; set; }

        public string Region { get; set; }

        public string Email { get; set; }

        // This property will store list of strings as "ProductName ProductKey" e.g. "IntelliVue X3"
        public IEnumerable<string> SelectedModels { get; set; }

        public bool isRequestCompleted { get; set; }
    }
}
