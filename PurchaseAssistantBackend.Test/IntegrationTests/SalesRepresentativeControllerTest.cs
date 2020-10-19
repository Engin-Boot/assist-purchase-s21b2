using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Net;
using PurchaseAssistantWebApp.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace PurchaseAssistantBackend.Test.IntegrationTests
{
    public class SalesRepresentativeControllerTest
    {
        private readonly TestProgram _program;
        private static string url = "http://localhost:5000/api/SalesRepresentative";

        public SalesRepresentativeControllerTest()
        {
            _program = new TestProgram();
        }

        [Fact]
        public async Task Get_ShouldReturnAllSalesRepresentativesWithHttpStatusOk()
        {
            var response = await _program.Client.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        private SalesRepresentative HelperMethodToCreateNewSalesRepresentative()
        {
            return new SalesRepresentative { Id = "SR002", Name = "Ellie", Email = "ellie@gmail.com", DepartmentRegion = "France" };
        }

        [Fact]
        public async Task Post_WhenValidRequestSentThenAddSuccessfullyAndReturnHttpsStatusOk()
        {
            SalesRepresentative newSalesRepresentative = HelperMethodToCreateNewSalesRepresentative();

            var response = await _program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newSalesRepresentative), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_WhenInvalidRequestSentThenReturnHttpsStatusBadRequest()
        {
            SalesRepresentative newSalesRepresentative = new SalesRepresentative { Id = "SR002", Name = "Ellie", Email = "ellie@gmail.com"};

            var response = await _program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newSalesRepresentative), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Put_WhenValidRequestSentThenUpdateSuccessfullyAndReturnHttpsStatusOk()
        {
            // First add a new sales representative
            SalesRepresentative salesRepresentativeToBeUpdated = HelperMethodToCreateNewSalesRepresentative();
            _ = await _program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(salesRepresentativeToBeUpdated), Encoding.UTF8, "application/json"));

            // Then update and check result
            SalesRepresentative updatedSalesRepresentative = new SalesRepresentative { Id = "SR002", Name = "Ellie", Email = "ellie@gmail.com", DepartmentRegion = "Germany" };

            HttpResponseMessage response = await _program.Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(updatedSalesRepresentative), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task Put_WhenInvalidRequestWithNonExistentKeySentThenReturnHttpsStatusBadRequest()
        {
            SalesRepresentative salesRepresentativeWithNonExistentKey = new SalesRepresentative { Id = "SR0099", Name = "Ellie", Email = "ellie@gmail.com", DepartmentRegion = "Germany" };

            var response = await _program.Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(salesRepresentativeWithNonExistentKey), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Put_WhenInvalidRequestWithMissingEmailSentThenReturnHttpsStatusBadRequest()
        {
            SalesRepresentative salesRepresentativeWithMissingEmail = new SalesRepresentative { Id = "SR0042", Name = "Ellie", DepartmentRegion = "Germany" };

            var response = await _program.Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(salesRepresentativeWithMissingEmail), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Delete_WhenValidIdSentThenDeleteSuccessfullyAndReturnHttpsStatusOk()
        {
            // First add a new sales representative
            SalesRepresentative salesRepresentativeToBeDeleted = HelperMethodToCreateNewSalesRepresentative();
            _ = await _program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(salesRepresentativeToBeDeleted), Encoding.UTF8, "application/json"));

            // Then delete and check result
            HttpResponseMessage response = await _program.Client.DeleteAsync(url + "/SR002");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task Delete_WhenInvalidRequestWithNonExistentKeySentThenReturnHttpsStatusBadRequest()
        {
            var response = await _program.Client.DeleteAsync(url + "/SR0097");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
