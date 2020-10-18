using PurchaseAssistantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseAssistantWebApp.Repository
{
    public class CallSetupRequestDataRepository : ICallSetupRequestDataRepository
    {
        List<CallSetupRequest> requestsDb = new List<CallSetupRequest>();

        public CallSetupRequestDataRepository()
        {

        }

        public CallSetupRequestDataRepository(List<CallSetupRequest> initialRequestDb)
        {
            foreach (CallSetupRequest requestInfo in initialRequestDb)
            {
                requestsDb.Add(requestInfo);
            }
        }
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
            ValidateField("requestId", request.RequestId);
            ValidateField("email", request.Email);
            ValidateField("organisation", request.Organisation);
            ValidateField("pointOfContactName", request.PointOfContactName);
            ValidateField("region", request.Region);

            if (request.SelectedModels==null || !request.SelectedModels.Any())
            {
                throw new ArgumentNullException("selectedModels", "Selected models cannot be null or empty. Please select atleast one model to make a request.");
            }
        }

        public string AddNewCallSetupRequest(CallSetupRequest newRequest)
        {
            ValidateCallSetupRequestData(newRequest);

            for (var i = 0; i < requestsDb.Count; i++)
            {
                if (requestsDb[i].RequestId.Equals(newRequest.RequestId))
                {
                    throw new ArgumentException("A Call Setup Request with " + newRequest.RequestId + " key already exists.","requestId");
                }
            }
            requestsDb.Add(newRequest);
            return String.Format("Call Setup Request with id {0} added successfully!", newRequest.RequestId);
        }

        public string DeleteCallSetupRequest(string id)
        {
            int totalRequests = requestsDb.Count;
            for (var i = 0; i < totalRequests; i++)
            {
                if (requestsDb[i].RequestId.Equals(id))
                {
                    requestsDb.RemoveAt(i);
                    return String.Format("Call Setup Request with id {0} deleted successfully!", id);
                }
            }
            throw new KeyNotFoundException("Delete operation failed. Call Setup Request with " + id + " key does not exist.");
        }

        public string UpdateCallSetupRequest(CallSetupRequest request)
        {
            ValidateCallSetupRequestData(request);

            for (var i = 0; i < requestsDb.Count; i++)
            {
                if (requestsDb[i].RequestId.Equals(request.RequestId))
                {
                    requestsDb[i].Email = request.Email;
                    requestsDb[i].Organisation = request.Organisation;
                    requestsDb[i].PointOfContactName = request.PointOfContactName;
                    requestsDb[i].Region = request.Region;
                    requestsDb[i].SelectedModels = new List<string>(request.SelectedModels);
                    return String.Format("Call Setup Request with id {0} updated successfully!", request.RequestId);
                }
            }
            throw new KeyNotFoundException("Update operation failed. Call Setup Request with " + request.RequestId + " key does not exist.");
        }
    }
}
