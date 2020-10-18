using PurchaseAssistantWebApp.Models;
using PurchaseAssistantWebApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PurchaseAssistantBackend.Test
{
    public class CallSetupRequestDataRepositoryTest
    {
        private ICallSetupRequestDataRepository repository;
        public CallSetupRequestDataRepositoryTest()
        {
            var requestsTestDb = new List<CallSetupRequest>();
            
            requestsTestDb.Add(new CallSetupRequest { 
                RequestId = "REQ001", 
                PointOfContactName = "James", 
                Organisation = "XYZ Hospital", 
                Email = "james@xyz.com", 
                Region = "Italy", 
                SelectedModels = new List<string> { "IntelliVue X3", "IntelliVue X40" } 
            });

            requestsTestDb.Add(new CallSetupRequest
            {
                RequestId = "REQ002",
                PointOfContactName = "Sara",
                Organisation = "ABC Hospital",
                Email = "sara@abc.com",
                Region = "India",
                SelectedModels = new List<string> { "IntelliVue X3" }
            });

            repository = new CallSetupRequestDataRepository(requestsTestDb);
        }

        [Fact]
        public void WhenGetAllCallSetupRequestThenReturnAllRequests()
        {
            var requests = repository.GetAllCallSetupRequest() as List<CallSetupRequest>;

            Assert.Equal(2, requests.Count);

            Assert.Equal("REQ001", requests[0].RequestId);
            Assert.Equal("James", requests[0].PointOfContactName);
            Assert.Equal("XYZ Hospital", requests[0].Organisation);
            Assert.Equal("james@xyz.com", requests[0].Email);
            Assert.Equal("Italy", requests[0].Region);
            Assert.Equal(2, requests[0].SelectedModels.Count());

            Assert.Equal("REQ002", requests[1].RequestId);
            Assert.Equal("Sara", requests[1].PointOfContactName);
            Assert.Equal("ABC Hospital", requests[1].Organisation);
            Assert.Equal("sara@abc.com", requests[1].Email);
            Assert.Equal("India", requests[1].Region);
            Assert.Single(requests[1].SelectedModels);
        }

        [Fact]
        public void WhenAddCallSetupRequestWithValidFieldsAndUniqueIdThenReturnSuccessMessage()
        {
            var message = repository.AddNewCallSetupRequest(
                new CallSetupRequest {
                    RequestId = "REQ003",
                    PointOfContactName = "George",
                    Organisation = "PQRS Hospital",
                    Email = "george@pqrs.com",
                    Region = "USA",
                    SelectedModels = new List<string> { "IntelliVue X40" }
                });

            Assert.Equal("Call Setup Request with id REQ003 added successfully!", message);
        }
        
        [Fact]
        public void WhenAddCallSetupRequestWithValidFieldsAndDuplicateIdThenThrowArgumentException()
        {
            try
            {
                var message = repository.AddNewCallSetupRequest(
                    new CallSetupRequest
                    {
                        RequestId = "REQ001",
                        PointOfContactName = "George",
                        Organisation = "PQRS Hospital",
                        Email = "george@pqrs.com",
                        Region = "USA",
                        SelectedModels = new List<string> { "IntelliVue X40" }
                    });
            }
            catch (ArgumentException exception)
            {
                Assert.Equal("requestId", exception.ParamName);
                Assert.Equal("A Call Setup Request with REQ001 key already exists. (Parameter 'requestId')", exception.Message);
            }
        }

        [Fact]
        public void WhenAddCallSetupRequestWithZeroSelectedModelsThenThrowArgumentException()
        {
            try
            {
                var message = repository.AddNewCallSetupRequest(
                    new CallSetupRequest
                    {
                        RequestId = "REQ003",
                        PointOfContactName = "George",
                        Organisation = "PQRS Hospital",
                        Email = "george@pqrs.com",
                        Region = "USA",
                        SelectedModels = new List<string> { }
                    });
            }
            catch (ArgumentNullException exception)
            {
                Assert.Equal("selectedModels", exception.ParamName);
                Assert.Equal("Selected models cannot be null or empty. Please select atleast one model to make a request. (Parameter 'selectedModels')", exception.Message);
            }
        }


        [Fact]
        public void WhenUpdateCallSetupRequestWithValidFieldsAndExistingIdThenReturnSuccessMessage()
        {
            var message = repository.UpdateCallSetupRequest(
                new CallSetupRequest
                {
                    RequestId = "REQ001",
                    PointOfContactName = "James",
                    Organisation = "XYZ Hospital",
                    Email = "james@xyz.com",
                    Region = "Italy",
                    SelectedModels = new List<string> { "IntelliVue X40" }
                });

            Assert.Equal("Call Setup Request with id REQ001 updated successfully!", message);
        }
        
        [Fact]
        public void WhenUpdateCallSetupRequestWithNonExistingIdThenThrowKeyNotFoundException()
        {
            try
            {
                var message = repository.UpdateCallSetupRequest(
                new CallSetupRequest
                {
                    RequestId = "REQ005",
                    PointOfContactName = "Katie",
                    Organisation = "XYZ Hospital",
                    Email = "katie@xyz.com",
                    Region = "Italy",
                    SelectedModels = new List<string> { "IntelliVue X40" }
                });

            }
            catch (KeyNotFoundException exception)
            {
                Assert.Equal("Update operation failed. Call Setup Request with REQ005 key does not exist.", exception.Message);
            }
        }
        
        [Fact]
        public void WhenUpdateCallSetupRequestWithInvalidFieldsThenThrowArgumentException()
        {
            try
            {
                var message = repository.UpdateCallSetupRequest(
                new CallSetupRequest
                {
                    RequestId = "REQ001",
                    PointOfContactName = "",
                    Organisation = "XYZ Hospital",
                    Email = "katie@xyz.com",
                    Region = "Italy",
                    SelectedModels = new List<string> { "IntelliVue X40" }
                });
            }
            catch (ArgumentNullException exception)
            {
                Assert.Equal("pointOfContactName", exception.ParamName);
                Assert.Equal("Customer detail required: pointOfContactName cannot be null or empty. (Parameter 'pointOfContactName')", exception.Message);
            }
        }
        
        [Fact]
        public void WhenDeleteCallSetupRequestWithExistingIdThenReturnSuccessMessage()
        {
            var message = repository.DeleteCallSetupRequest("REQ001");

            Assert.Equal("Call Setup Request with id REQ001 deleted successfully!", message);
        }
        
        [Fact]
        public void WhenDeleteCallSetupRequestWithNonExistingIdThenThrowKeyNotFoundException()
        {
            try
            {
                var message = repository.DeleteCallSetupRequest("REQ010");
            }
            catch (KeyNotFoundException exception)
            {
                Assert.Equal("Delete operation failed. Call Setup Request with REQ010 key does not exist.", exception.Message);
            }
        }
        
        [Fact]
        public void WhenCallSetupRequestDataRepositoryCreatedWithDefaultConstructorThenNonEmptyRepository()
        {
            ICallSetupRequestDataRepository repository = new CallSetupRequestDataRepository();
            Assert.NotNull(repository);
        }

        [Fact]
        public void WhenCallValidateCallSetupRequestDataMethodWithoutSelectedModelsThenThrowException()
        {
            try
            {
                var message = repository.AddNewCallSetupRequest(
                    new CallSetupRequest
                    {
                        RequestId = "REQ003",
                        PointOfContactName = "George",
                        Organisation = "PQRS Hospital",
                        Email = "george@pqrs.com",
                        Region = "USA"
                    });
            }
            catch (ArgumentNullException exception)
            {
                Assert.Equal("selectedModels", exception.ParamName);
                Assert.Equal("Selected models cannot be null or empty. Please select atleast one model to make a request. (Parameter 'selectedModels')", exception.Message);
            }
        }
    }
}
