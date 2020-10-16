using PurchaseAssistantWebApp.Models;

namespace PurchaseAssistantWebApp.Utilities
{
    public class AlertByEmail : IAlerter
    {
        public event CustomerRequestHandler CustomerRequestReceived;
        public void SendAlert(CallSetupRequest customerInfo)
        {
            this.CustomerRequestReceived.Invoke(customerInfo);
        }
    }
}
