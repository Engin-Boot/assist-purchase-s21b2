using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using PurchaseAssistantWebApp;

namespace PurchaseAssistantBackend.Test
{
    public class DummyProgram
    {
        public HttpClient Client { get; private set; }
        private TestServer _server;
        public DummyProgram()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();
        }
  
    }
}