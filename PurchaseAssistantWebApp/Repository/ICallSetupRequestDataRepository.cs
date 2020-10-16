using PurchaseAssistantWebApp.Models;
using System.Collections.Generic;
using System.Net;

namespace PurchaseAssistantWebApp.Repository
{
    interface ICallSetupRequestDataRepository
    {
        IEnumerable<CallSetupRequest> GetAllCallSetupRequest();

        HttpStatusCode AddNewCallSetupRequest(CallSetupRequest newRequest);

        HttpStatusCode UpdateCallSetupRequest(CallSetupRequest request);

        HttpStatusCode UpdateCallSetupRequestStatus(long id, bool isRequestCompleted);

        HttpStatusCode DeleteCallSetupRequest(long id);
    }
}
