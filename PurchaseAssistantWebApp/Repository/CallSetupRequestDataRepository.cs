using JetBrains.Annotations;
using PurchaseAssistantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PurchaseAssistantWebApp.Repository
{
    public class CallSetupRequestDataRepository : ICallSetupRequestDataRepository
    {
        private readonly List<CallSetupRequest> _requestsDb = new List<CallSetupRequest>();

        public CallSetupRequestDataRepository()
        {

        }

        public CallSetupRequestDataRepository(List<CallSetupRequest> initialRequestDb)
        {
            foreach (CallSetupRequest requestInfo in initialRequestDb)
            {
                _requestsDb.Add(requestInfo);
            }
        }
        public IEnumerable<CallSetupRequest> GetAllCallSetupRequest()
        {
            return _requestsDb;
        }

        [AssertionMethod]
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
                throw new ArgumentNullException(nameof(request.SelectedModels), "Selected models cannot be null or empty. Please select atleast one model to make a request.");
            }
        }

        public string AddNewCallSetupRequest(CallSetupRequest newRequest)
        {
            ValidateCallSetupRequestData(newRequest);

            foreach (CallSetupRequest request in _requestsDb)
            {
                if (request.RequestId.Equals(newRequest.RequestId))
                {
                    throw new ArgumentException("A Call Setup Request with " + newRequest.RequestId + " key already exists.", nameof(newRequest.RequestId));
                }
            }
            _requestsDb.Add(newRequest);
            return $"Call Setup Request with id {newRequest.RequestId} added successfully!";
        }

        public string DeleteCallSetupRequest(string id)
        {
            int totalRequests = _requestsDb.Count;
            for (var i = 0; i < totalRequests; i++)
            {
                if (_requestsDb[i].RequestId.Equals(id))
                {
                    _requestsDb.RemoveAt(i);
                    return $"Call Setup Request with id {id} deleted successfully!";
                }
            }
            throw new KeyNotFoundException("Delete operation failed. Call Setup Request with " + id + " key does not exist.");
        }

        public string UpdateCallSetupRequest(CallSetupRequest request)
        {
            ValidateCallSetupRequestData(request);

            foreach (CallSetupRequest v in _requestsDb)
            {
                if (v.RequestId.Equals(request.RequestId))
                {
                    v.Email = request.Email;
                    v.Organisation = request.Organisation;
                    v.PointOfContactName = request.PointOfContactName;
                    v.Region = request.Region;
                    v.SelectedModels = new List<string>(request.SelectedModels);
                    return $"Call Setup Request with id {request.RequestId} updated successfully!";
                }
            }
            throw new KeyNotFoundException("Update operation failed. Call Setup Request with " + request.RequestId + " key does not exist.");
        }
    }
}
