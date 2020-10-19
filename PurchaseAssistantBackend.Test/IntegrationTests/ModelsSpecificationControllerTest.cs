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
        private readonly TestProgram program;
        private static string url = "http://localhost:5000/api/ModelsSpecification";

        public ModelsSpecificationControllerTest()
        {
            program = new TestProgram();
        }

        [Fact]
        public async Task Get_ShouldReturnAllModelsWithHttpStatusOk()
        {
            var response = await program.Client.GetAsync(url);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Post_WhenValidModelDetailsSentThenAddSuccessfullyAndReturnHttpsStatusOk()
        {
            ModelsSpecification newModel = new ModelsSpecification
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
            };

            var response = await program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newModel), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Put_WhenValidModelDetailsSentThenUpdateSuccessfullyAndReturnHttpsStatusOk()
        {
            // First add a new model
            ModelsSpecification newModelInfo = new ModelsSpecification
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
                MonitorResolution = "10*14",
                BatterySupport = "NO",
                MultiPatientSupport = "NO",
            };

            var response = await program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newModelInfo), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Then update and check result
            ModelsSpecification model = new ModelsSpecification
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
            };

            response = await program.Client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task Delete_WhenValidModelIdSentThenDeleteSuccessfullyAndReturnHttpsStatusOk()
        {
            ModelsSpecification newModelSpec = new ModelsSpecification
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
                MonitorResolution = "10*15",
                BatterySupport = "NO",
                MultiPatientSupport = "NO",
            };

            var response = await program.Client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(newModelSpec), Encoding.UTF8, "application/json"));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            response = await program.Client.DeleteAsync(url + "/52");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }
    }
}
