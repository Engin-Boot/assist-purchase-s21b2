namespace PurchaseAssistantWebApp.Utilities
{
    public delegate void CustomerRequestHandler(Models.CallSetupRequest customerInfo);
    interface IAlerter
    {
        public void SendAlert(Models.CallSetupRequest customerInfo);
    }
}
