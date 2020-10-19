using Newtonsoft.Json;
using PurchaseAssistantWebApp.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PurchaseAssistantBackend.Test.IntegrationTests
{
    public class CallSetupRequestControllerTest
    {
        private readonly TestProgram _program;
        private static string url = "http://localhost:5000/api/CallSetupRequest";

        public CallSetupRequestControllerTest()
        {
            _program = new TestProgram();
        }

        [Fact]
        public async Task Get_ShouldReturnAllRequestsWithHttpStatusOk()
        {
            var response = await _program.Client.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        private CallSetupRequest HelperMethodToCreateNewCallSetupRequest()
        {
            CallSetupRequest newCallSetupRequest = new CallSetupRequest
            {
                RequestId = "REQ013",
                PointOfContactName = "James",
                Organisation = "XYZ Hospital",
                Email = "james@xyz.com",
                Region = "Singapore",
                SelectedModels = new List<string> { "IntelliVue X3", "IntelliVue X40" }
            };

            return newCallSetupRequest;
        }

        [Fact]
        public async Task Post_WhenValidCallSetupRequestSentThenAddSuccessfullyAndReturnHttpsStatusOk()
        {
            var newCallSetupRequest = HelperMethodToCreateNewCallSetupRequest();

            var response = await _program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newCallSetupRequest), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_WhenInvalidCallSetupRequestWithoutEmailSentThenReturnHttpsStatusBadRequest()
        {
            CallSetupRequest newCallSetupRequestWithoutEmail = new CallSetupRequest
            {
                RequestId = "REQ011",
                PointOfContactName = "James",
                Organisation = "XYZ Hospital",
                Region = "Italy",
                SelectedModels = new List<string> { "IntelliVue X3", "IntelliVue X40" }
            };

            var response = await _program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newCallSetupRequestWithoutEmail), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }


        [Fact]
        public async Task Put_WhenValidCallSetupRequestSentThenUpdateSuccessfullyAndReturnHttpsStatusOk()
        {
            // First add a new request
            CallSetupRequest callSetupRequestToUpdate = HelperMethodToCreateNewCallSetupRequest();
            _ = await _program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(callSetupRequestToUpdate), Encoding.UTF8, "application/json"));

            // Then update and check result
            CallSetupRequest updatedCallSetupRequest = new CallSetupRequest
            {
                RequestId = "REQ013",
                PointOfContactName = "James Mathew",
                Organisation = "XYZ Hospital",
                Email = "james@xyz.com",
                Region = "Slovania",
                SelectedModels = new List<string> { "IntelliVue X3", "IntelliVue X40" }
            };

            HttpResponseMessage response = await _program.Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(updatedCallSetupRequest), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task Put_WhenInvalidCallSetupRequestWithNonExistentKeySentThenReturnHttpsStatusBadRequest()
        {
            CallSetupRequest request = new CallSetupRequest
            {
                RequestId = "REQ015",
                PointOfContactName = "James",
                Organisation = "XYZ Hospital",
                Email = "james@xyz.com",
                Region = "Italy",
                SelectedModels = new List<string> { "IntelliVue X3", "IntelliVue X40" }
            };

            var response = await _program.Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Put_WhenInvalidCallSetupRequestWithMissingRegionSentThenReturnHttpsStatusBadRequest()
        {
            CallSetupRequest requestWithMissingRegion = new CallSetupRequest
            {
                RequestId = "REQ015",
                PointOfContactName = "James",
                Organisation = "XYZ Hospital",
                Email = "james@xyz.com",
                SelectedModels = new List<string> { "IntelliVue X3", "IntelliVue X40" }
            };
            var response = await _program.Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(requestWithMissingRegion), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Delete_WhenValidRequestIdSentThenDeleteSuccessfullyAndReturnHttpsStatusOk()
        {
            CallSetupRequest newCallSetupRequestToBeDeleted = HelperMethodToCreateNewCallSetupRequest();
            
            _ = await _program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newCallSetupRequestToBeDeleted), Encoding.UTF8, "application/json"));

            HttpResponseMessage response = await _program.Client.DeleteAsync(url + "/REQ013");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task Delete_WhenInvalidRequestWithNonExistentRequestIdSentThenReturnHttpsStatusBadRequest()
        {
            var response = await _program.Client.DeleteAsync(url + "/REQ0097");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
