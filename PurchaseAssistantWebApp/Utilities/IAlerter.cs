namespace PurchaseAssistantWebApp.Utilities
{
    interface IAlerter
    {
        public void SendAlert(Models.CallSetupRequest requestInfo);
    }
}
