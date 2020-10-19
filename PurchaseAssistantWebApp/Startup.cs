using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace PurchaseAssistantWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddSingleton<Repository.IModelsSpecificationDataRepository, Repository.ModelsSpecificationDataRepository>();
            services.AddSingleton<Repository.ICallSetupRequestDataRepository, Repository.CallSetupRequestDataRepository>();
            services.AddSingleton<Repository.ISalesRepresentativeDataRepository, Repository.SalesRepresentativeDataRepository>();
            services.AddSingleton<Utilities.IAlerter, Utilities.AlertByEmail>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
