using PurchaseAssistantWebApp.Models;
using System.Collections.Generic;
using System.Net;

namespace PurchaseAssistantWebApp.Repository
{
    public interface ICallSetupRequestDataRepository
    {
        IEnumerable<CallSetupRequest> GetAllCallSetupRequest();

        void AddNewCallSetupRequest(CallSetupRequest newRequest);

        void UpdateCallSetupRequest(CallSetupRequest request);

        void DeleteCallSetupRequest(string id);
    }
}
