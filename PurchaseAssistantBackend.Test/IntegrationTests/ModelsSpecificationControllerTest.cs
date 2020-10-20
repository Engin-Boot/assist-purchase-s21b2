using Newtonsoft.Json;
using PurchaseAssistantWebApp.Models;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PurchaseAssistantBackend.Test.IntegrationTests
{
    public class ModelsSpecificationControllerTest
    {
        private readonly TestProgram _program;
        private static string url = "http://localhost:5000/api/ModelsSpecification";

        public ModelsSpecificationControllerTest()
        {
            _program = new TestProgram();
        }

        [Fact]
        public async Task Get_ShouldReturnAllModelsWithHttpStatusOk()
        {
            var response = await _program.Client.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        private ModelsSpecification HelperMethodToCreateNewModelSpecification()
        {
            return new ModelsSpecification
            {
                Id = 52,
                ProductName = "IntelliVue",
                ProductKey = "X400",
                Description = "The Philips IntelliVue X400 is a dual-purpose, transport patient monitor.",
                Price = "14500",
                Weight = 65,
                Portable = true,
                ScreenSize = 6.1,
                TouchScreenSupport = true,
                MonitorResolution = "10*11",
                BatterySupport = "NO",
                MultiPatientSupport = "NO",
                BpCheck = "YES",
                HeartRateCheck = "YES",
                EcgCheck = "NO",
                SpO2Check = "NO",
                TemperatureCheck = "YES",
                CardiacOutputCheck = "NO"
            };
        }

        [Fact]
        public async Task Post_WhenValidModelDetailsSentThenAddSuccessfullyAndReturnHttpsStatusOk()
        {
            ModelsSpecification newModel = HelperMethodToCreateNewModelSpecification();

            var response = await _program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newModel), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_WhenInvalidRequestSentThenReturnHttpsStatusBadRequest()
        {
            ModelsSpecification newModelWithIncompleteSpecs = new ModelsSpecification { Id = 22, ProductKey = "IntelliVue" };

            var response = await _program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newModelWithIncompleteSpecs), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Post_WhenValidModelDetailsSentWithDuplicateKeyThenReturnHttpStatusBadRequest()
        {
            ModelsSpecification newModel = HelperMethodToCreateNewModelSpecification();

            _ = await _program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newModel), Encoding.UTF8, "application/json"));
            var response = await _program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newModel), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Put_WhenValidModelDetailsSentThenUpdateSuccessfullyAndReturnHttpsStatusOk()
        {
            // First add a new model
            ModelsSpecification modelToBeUpdated = HelperMethodToCreateNewModelSpecification();
            _ = await _program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(modelToBeUpdated), Encoding.UTF8, "application/json"));

            // Then update and check result
            ModelsSpecification updatedModelSpecification = new ModelsSpecification
            {
                Id = 52,
                ProductName = "IntelliVue",
                ProductKey = "X400",
                Description = "The Philips IntelliVue X400 is a dual-purpose, transport patient monitor.",
                Price = "14500",
                Weight = 65,
                Portable = true,
                ScreenSize = 6.1,
                TouchScreenSupport = true,
                MonitorResolution = "10*16",
                BatterySupport = "YES",
                MultiPatientSupport = "NO",
                BpCheck = "YES",
                HeartRateCheck = "YES",
                EcgCheck = "NO",
                SpO2Check = "YES",
                TemperatureCheck = "YES",
                CardiacOutputCheck = "YES"
            };

            HttpResponseMessage response = await _program.Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(updatedModelSpecification), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Put_WhenInvalidRequestWithNonExistentKeySentThenReturnHttpsStatusBadRequest()
        {
            ModelsSpecification modelWithNonExistentKey = new ModelsSpecification { 
                Id = 76,
                ProductName = "IntelliVue",
                ProductKey = "X400",
                Description = "The Philips IntelliVue X500",
                Price = "14500",
                Weight = 65,
                Portable = true,
                ScreenSize = 6.1,
                TouchScreenSupport = true,
                MonitorResolution = "10*11",
                BatterySupport = "NO",
                MultiPatientSupport = "NO",
                BpCheck = "YES",
                HeartRateCheck = "YES",
                EcgCheck = "NO",
                SpO2Check = "YES",
                TemperatureCheck = "YES",
                CardiacOutputCheck = "NO"
            };

            var response = await _program.Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(modelWithNonExistentKey), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Put_WhenInvalidRequestWithMissingSpecsSentThenReturnHttpsStatusBadRequest()
        {
            ModelsSpecification modelWithMissingSpecs = new ModelsSpecification {
                Id = 33,
                ProductName = "IntelliVue",
                ProductKey = "X400",
            };

            var response = await _program.Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(modelWithMissingSpecs), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task Delete_WhenValidModelIdSentThenDeleteSuccessfullyAndReturnHttpsStatusOk()
        {
            ModelsSpecification modelToBeDeleted = HelperMethodToCreateNewModelSpecification();
            _ = await _program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(modelToBeDeleted), Encoding.UTF8, "application/json"));

            var response = await _program.Client.DeleteAsync(url + "/52");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Fact]
        public async Task Delete_WhenInvalidRequestWithNonExistentKeySentThenReturnHttpsStatusBadRequest()
        {
            var response = await _program.Client.DeleteAsync(url + "/933");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
