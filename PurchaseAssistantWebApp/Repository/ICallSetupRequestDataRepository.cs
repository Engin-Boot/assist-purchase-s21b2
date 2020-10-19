using PurchaseAssistantWebApp.Models;
using System.Collections.Generic;

namespace PurchaseAssistantWebApp.Repository
{
    public interface ICallSetupRequestDataRepository
    {
        IEnumerable<CallSetupRequest> GetAllCallSetupRequest();

        string AddNewCallSetupRequest(CallSetupRequest newRequest);

        string UpdateCallSetupRequest(CallSetupRequest request);

        string DeleteCallSetupRequest(string id);
    }
}
