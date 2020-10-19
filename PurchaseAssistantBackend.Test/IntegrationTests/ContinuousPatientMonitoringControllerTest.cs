using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PurchaseAssistantBackend.Test.IntegrationTests
{
    public class ContinuousPatientMonitoringControllerTest
    {
        private readonly TestProgram program;
        private static string url = "http://localhost:5000/api/ContinuousPatientMonitoringSystems";

        public ContinuousPatientMonitoringControllerTest()
        {
            program = new TestProgram();
        }

        [Fact]
        public async Task Get_WhenQueryHasValidParameterValuesThenReturnFilteredModelsWithHttpStatusOk()
        {
            string query = "Portability=true";

            var response = await program.Client.GetAsync(url + "?" + query);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Get_WhenQueryHasInvalidParameterValuesThenReturnFilteredModelsWithHttpStatusBadRequest()
        {
            string query = "Portability=any";

            var response = await program.Client.GetAsync(url + "?" + query);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
