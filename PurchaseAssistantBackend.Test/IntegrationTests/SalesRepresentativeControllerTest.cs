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
        private readonly TestProgram program;
        private static string url = "http://localhost:5000/api/SalesRepresentative";

        public SalesRepresentativeControllerTest()
        {
            program = new TestProgram();
        }

        [Fact]
        public async Task Get_ShouldReturnAllSalesRepresentativesWithHttpStatusOk()
        {
            var response = await program.Client.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_WhenValidRequestSentThenAddSuccessfullyAndReturnHttpsStatusOk()
        {
            SalesRepresentative newSalesRepresentative = new SalesRepresentative { Id = "SR002", Name = "Ellie", Email = "ellie@gmail.com", DepartmentRegion = "France" };

            var response = await program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newSalesRepresentative), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_WhenInvalidRequestSentThenReturnHttpsStatusBadRequest()
        {
            SalesRepresentative newSalesRepresentative = new SalesRepresentative { Id = "SR002", Name = "Ellie", Email = "ellie@gmail.com"};

            var response = await program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newSalesRepresentative), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Put_WhenValidRequestSentThenUpdateSuccessfullyAndReturnHttpsStatusOk()
        {
            // First add a new sales representative
            SalesRepresentative newSalesRepresentative = new SalesRepresentative { Id = "SR0042", Name = "Ellie", Email = "ellie@gmail.com", DepartmentRegion = "France" };

            var response = await program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newSalesRepresentative), Encoding.UTF8, "application/json"));
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Then update and check result
            SalesRepresentative salesRepresentative = new SalesRepresentative { Id = "SR0042", Name = "Ellie", Email = "ellie@gmail.com", DepartmentRegion = "Germany" };

            response = await program.Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(salesRepresentative), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task Put_WhenInvalidRequestWithNonExistentKeySentThenReturnHttpsStatusBadRequest()
        {
            SalesRepresentative salesRepresentative = new SalesRepresentative { Id = "SR0099", Name = "Ellie", Email = "ellie@gmail.com", DepartmentRegion = "Germany" };

            var response = await program.Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(salesRepresentative), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Put_WhenInvalidRequestWithMissingEmailSentThenReturnHttpsStatusBadRequest()
        {
            SalesRepresentative salesRepresentativeWithoutEmail = new SalesRepresentative { Id = "SR0042", Name = "Ellie", DepartmentRegion = "Germany" };

            var response = await program.Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(salesRepresentativeWithoutEmail), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Delete_WhenValidIdSentThenDeleteSuccessfullyAndReturnHttpsStatusOk()
        {
            // First add a new sales representative
            SalesRepresentative newSalesRepresentative = new SalesRepresentative { Id = "SR0042", Name = "jack", Email = "jack@gmail.com", DepartmentRegion = "France" };

            var response = await program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newSalesRepresentative), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Then delete and check result

            response = await program.Client.DeleteAsync(url + "/SR0042");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task Delete_WhenInvalidRequestWithNonExistentKeySentThenReturnHttpsStatusBadRequest()
        {

            var response = await program.Client.DeleteAsync(url + "/SR0097");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
