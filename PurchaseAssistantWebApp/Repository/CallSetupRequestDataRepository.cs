using PurchaseAssistantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace PurchaseAssistantWebApp.Repository
{
    public class CallSetupRequestDataRepository : ICallSetupRequestDataRepository
    {
        List<CallSetupRequest> requestsDb = new List<CallSetupRequest>();
        public IEnumerable<CallSetupRequest> GetAllCallSetupRequest()
        {
            return requestsDb;
        }

        public HttpStatusCode AddNewCallSetupRequest(CallSetupRequest newRequest)
        {
            for (var i = 0; i < requestsDb.Count; i++)
            {
                if (requestsDb[i].Id == newRequest.Id)
                {
                    return HttpStatusCode.BadRequest;
                }
            }
            requestsDb.Add(newRequest);
            return HttpStatusCode.OK;
        }

        public HttpStatusCode DeleteCallSetupRequest(long id)
        {
            int totalRequests = requestsDb.Count;
            for (var i = 0; i < totalRequests; i++)
            {
                if (requestsDb[i].Id == id)
                {
                    requestsDb.RemoveAt(i);
                    return HttpStatusCode.OK;
                }
            }
            return HttpStatusCode.NotFound;
        }

        public HttpStatusCode UpdateCallSetupRequest(CallSetupRequest request)
        {
            for (var i = 0; i < requestsDb.Count; i++)
            {
                if (requestsDb[i].Id == request.Id)
                {
                    requestsDb[i].Email = request.Email;
                    requestsDb[i].Organisation = request.Organisation;
                    requestsDb[i].PointOfContactName = request.PointOfContactName;
                    requestsDb[i].Region = request.Region;
                    requestsDb[i].SelectedModels = new List<long>(request.SelectedModels);
                    return HttpStatusCode.OK;
                }
            }

            return HttpStatusCode.NotFound;
        }

        public HttpStatusCode UpdateCallSetupRequestStatus(long id, bool isRequestCompleted)
        {
            for (var i = 0; i < requestsDb.Count; i++)
            {
                if (requestsDb[i].Id == id)
                {
                    requestsDb[i].isRequestCompleted = isRequestCompleted;
                    return HttpStatusCode.OK;
                }
            }

            return HttpStatusCode.NotFound;
        }
    }
}
