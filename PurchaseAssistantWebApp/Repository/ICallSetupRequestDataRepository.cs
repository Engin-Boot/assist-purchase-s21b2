using PurchaseAssistantWebApp.Models;
using System.Collections.Generic;
using System.Net;

namespace PurchaseAssistantWebApp.Repository
{
    interface ICallSetupRequestDataRepository
    {
        IEnumerable<CallSetupRequest> GetAllCallSetupRequest();

        HttpStatusCode AddNewCallSetupRequest(CallSetupRequest newRequest);

        HttpStatusCode UpdateCallSetupRequest(long id, CallSetupRequest request);

        HttpStatusCode DeleteCallSetupRequest(long id);
    }
}
