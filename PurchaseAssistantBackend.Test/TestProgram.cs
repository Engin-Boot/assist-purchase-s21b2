using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using PurchaseAssistantWebApp;

namespace PurchaseAssistantBackend.Test
{
    public class TestProgram
    {
        private readonly TestServer _server;

        public HttpClient Client { get; }
        public TestProgram()
        {
            //IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            //// Duplicate here any configuration sources you use.
            //configurationBuilder.AddJsonFile("AppSettings.json");
            //IConfiguration configuration = configurationBuilder.Build();
            //var projectDir = GetProjectPath("", typeof(Startup).GetTypeInfo().Assembly);
            //_server = new TestServer(new WebHostBuilder()
            //            .UseEnvironment("Development")
            //            .UseContentRoot(projectDir)
            //            .UseConfiguration(new ConfigurationBuilder()
            //                .SetBasePath(projectDir)
            //                .AddJsonFile("appsettings.json")
            //                .Build()
            //            )
            //            .UseStartup<Startup>());
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();
        }

        //private static string GetProjectPath(string projectRelativePath, Assembly startupAssembly)
        //{
        //    // Get name of the target project which we want to test
        //    var projectName = startupAssembly.GetName().Name;

        //    // Get currently executing test project path
        //    var applicationBasePath = System.AppContext.BaseDirectory;

        //    // Find the path to the target project
        //    var directoryInfo = new DirectoryInfo(applicationBasePath);
        //    do
        //    {
        //        directoryInfo = directoryInfo.Parent;

        //        var projectDirectoryInfo = new DirectoryInfo(Path.Combine(directoryInfo.FullName, projectRelativePath));
        //        if (projectDirectoryInfo.Exists)
        //        {
        //            var projectFileInfo = new FileInfo(Path.Combine(projectDirectoryInfo.FullName, projectName, $"{projectName}.csproj"));
        //            if (projectFileInfo.Exists)
        //            {
        //                return Path.Combine(projectDirectoryInfo.FullName, projectName);
        //            }
        //        }
        //    }
        //    while (directoryInfo.Parent != null);

        //    throw new Exception($"Project root could not be located using the application root {applicationBasePath}.");
        //}

    }
}