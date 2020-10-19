using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using PurchaseAssistantWebApp;

namespace PurchaseAssistantBackend.Test
{
    public class TestProgram
    {
        public HttpClient Client { get; }
        public TestProgram()
        {
            TestServer server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
        }
  
    }
}