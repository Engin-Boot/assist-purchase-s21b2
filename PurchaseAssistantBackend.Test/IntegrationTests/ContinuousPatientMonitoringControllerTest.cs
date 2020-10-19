using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PurchaseAssistantBackend.Test.IntegrationTests
{
    public class ContinuousPatientMonitoringControllerTest
    {
        private readonly TestProgram _program;
        private static string url = "http://localhost:5000/api/ContinuousPatientMonitoringSystems";

        public ContinuousPatientMonitoringControllerTest()
        {
            _program = new TestProgram();
        }

        [Fact]
        public async Task Get_WhenQueryHasValidParameterValuesThenReturnFilteredModelsWithHttpStatusOk()
        {
            string query = "Portability=true";

            var response = await _program.Client.GetAsync(url + "?" + query);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_WhenQueryHasInvalidParameterValuesThenReturnFilteredModelsWithHttpStatusBadRequest()
        {
            string query = "Portability=any";

            var response = await _program.Client.GetAsync(url + "?" + query);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
