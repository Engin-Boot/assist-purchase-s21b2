using PurchaseAssistantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace PurchaseAssistantWebApp.Repository
{
    public class CallSetupRequestDataRepository : ICallSetupRequestDataRepository
    {
        List<CallSetupRequest> requestsDb = new List<CallSetupRequest>();

        private bool ValidateRequest(CallSetupRequest newRequest)
        {
            // TODO
            return true;
        }

        public IEnumerable<CallSetupRequest> GetAllCallSetupRequest()
        {
            return requestsDb;
        }

        public HttpStatusCode AddNewCallSetupRequest(CallSetupRequest newRequest)
        {
            if(ValidateRequest(newRequest))
            {
                requestsDb.Add(newRequest);
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.BadRequest;
        }

        public HttpStatusCode DeleteCallSetupRequest(long id)
        {
            throw new NotImplementedException();
        }

        public HttpStatusCode UpdateCallSetupRequest(long id, CallSetupRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
