using PurchaseAssistantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseAssistantWebApp.Repository
{
    public class CallSetupRequestDataRepository : ICallSetupRequestDataRepository
    {
        List<CallSetupRequest> requestsDb = new List<CallSetupRequest>();
        public IEnumerable<CallSetupRequest> GetAllCallSetupRequest()
        {
            return requestsDb;
        }

        private void ValidateField(string name, string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(name, "Customer detail required: " + name + " cannot be null or empty.");
            }
        }

        private void ValidateCallSetupRequestData(CallSetupRequest request)
        {
            ValidateField("serviceRequestId", request.ServiceRequestId);
            ValidateField("email", request.Email);
            ValidateField("organisation", request.Organisation);
            ValidateField("pointOfContactName", request.PointOfContactName);
            ValidateField("region", request.Region);

            if (request.SelectedModels==null || !request.SelectedModels.Any())
            {
                throw new ArgumentNullException("selectedModels", "Selected models cannot be null or empty. Please select atleast one model to make a request.");
            }
        }

        public void AddNewCallSetupRequest(CallSetupRequest newRequest)
        {
            ValidateCallSetupRequestData(newRequest);

            for (var i = 0; i < requestsDb.Count; i++)
            {
                if (requestsDb[i].ServiceRequestId.Equals(newRequest.ServiceRequestId))
                {
                    throw new ArgumentException("A Call Setup Request with " + newRequest.ServiceRequestId + " key already exists.","id");
                }
            }
            requestsDb.Add(newRequest);
        }

        public void DeleteCallSetupRequest(string id)
        {
            int totalRequests = requestsDb.Count;
            for (var i = 0; i < totalRequests; i++)
            {
                if (requestsDb[i].ServiceRequestId.Equals(id))
                {
                    requestsDb.RemoveAt(i);
                    return;
                }
            }
            throw new KeyNotFoundException("Delete operation failed. Call Setup Request with " + id + " key does not exist.");
        }

        public void UpdateCallSetupRequest(CallSetupRequest request)
        {
            ValidateCallSetupRequestData(request);

            for (var i = 0; i < requestsDb.Count; i++)
            {
                if (requestsDb[i].ServiceRequestId.Equals(request.ServiceRequestId))
                {
                    requestsDb[i].Email = request.Email;
                    requestsDb[i].Organisation = request.Organisation;
                    requestsDb[i].PointOfContactName = request.PointOfContactName;
                    requestsDb[i].Region = request.Region;
                    requestsDb[i].SelectedModels = new List<string>(request.SelectedModels);
                    return;
                }
            }
            throw new KeyNotFoundException("Update operation failed. Call Setup Request with " + request.ServiceRequestId + " key does not exist.");
        }
    }
}
