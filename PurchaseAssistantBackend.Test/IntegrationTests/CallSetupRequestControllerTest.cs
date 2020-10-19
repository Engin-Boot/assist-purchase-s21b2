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
        private readonly TestProgram program;
        private static string url = "http://localhost:5000/api/CallSetupRequest";

        public CallSetupRequestControllerTest()
        {
            program = new TestProgram();
        }

        [Fact]
        public async Task Get_ShouldReturnAllRequestsWithHttpStatusOk()
        {
            var response = await program.Client.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_WhenValidCallSetupRequestSentThenAddSuccessfullyAndReturnHttpsStatusOk()
        {
            CallSetupRequest newCallSetupRequest = new CallSetupRequest
            {
                RequestId = "REQ011",
                PointOfContactName = "James",
                Organisation = "XYZ Hospital",
                Email = "james@xyz.com",
                Region = "Italy",
                SelectedModels = new List<string> { "IntelliVue X3", "IntelliVue X40" }
            };

            var response = await program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newCallSetupRequest), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_WhenInvalidCallSetupRequestWithoutEmailSentThenReturnHttpsStatusBadRequest()
        {
            CallSetupRequest newCallSetupRequest = new CallSetupRequest
            {
                RequestId = "REQ011",
                PointOfContactName = "James",
                Organisation = "XYZ Hospital",
                Region = "Italy",
                SelectedModels = new List<string> { "IntelliVue X3", "IntelliVue X40" }
            };

            var response = await program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newCallSetupRequest), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }


        [Fact]
        public async Task Put_WhenValidCallSetupRequestSentThenUpdateSuccessfullyAndReturnHttpsStatusOk()
        {
            // First add a new request
            CallSetupRequest newCallSetupRequest = new CallSetupRequest
            {
                RequestId = "REQ011",
                PointOfContactName = "James",
                Organisation = "XYZ Hospital",
                Email = "james@xyz.com",
                Region = "Italy",
                SelectedModels = new List<string> { "IntelliVue X3", "IntelliVue X40" }
            };
            var response = await program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newCallSetupRequest), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Then update and check result
            CallSetupRequest request = new CallSetupRequest
            {
                RequestId = "REQ011",
                PointOfContactName = "James Mathew",
                Organisation = "XYZ Hospital",
                Email = "james@xyz.com",
                Region = "Slovania",
                SelectedModels = new List<string> { "IntelliVue X3", "IntelliVue X40" }
            };

            response = await program.Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

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

            var response = await program.Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Put_WhenInvalidCallSetupRequestWithMissingRegionSentThenReturnHttpsStatusBadRequest()
        {
            CallSetupRequest request = new CallSetupRequest
            {
                RequestId = "REQ015",
                PointOfContactName = "James",
                Organisation = "XYZ Hospital",
                Email = "james@xyz.com",
                SelectedModels = new List<string> { "IntelliVue X3", "IntelliVue X40" }
            };
            var response = await program.Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Delete_WhenValidRequestIdSentThenDeleteSuccessfullyAndReturnHttpsStatusOk()
        {
            // First add a new sales representative
            // First add a new request
            CallSetupRequest newCallSetupRequest = new CallSetupRequest
            {
                RequestId = "REQ011",
                PointOfContactName = "James",
                Organisation = "XYZ Hospital",
                Email = "james@xyz.com",
                Region = "Italy",
                SelectedModels = new List<string> { "IntelliVue X3", "IntelliVue X40" }
            };
            var response = await program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newCallSetupRequest), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Then delete and check result

            response = await program.Client.DeleteAsync(url + "/REQ011");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task Delete_WhenInvalidRequestWithNonExistentRequestIdSentThenReturnHttpsStatusBadRequest()
        {

            var response = await program.Client.DeleteAsync(url + "/REQ0097");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
