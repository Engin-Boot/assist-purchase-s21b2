using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PurchaseAssistantWebApp.Database;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace PurchaseAssistantWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options =>
            {
                //options.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
                options.UseSqlite("Data source= C:/Users/Ajay kumar/source/repos/assist-purchase-s21b2/PurchaseAssistantWebApp/PurchaseAssistant.db");
                //options.UseSqlite("Data source= D:/a/assist-purchase-s21b2/assist-purchase-s21b2/PurchaseAssistantWebApp/PurchaseAssistant.db");
            });
            services.AddScoped<Repository.IModelsSpecificationDataRepository, Repository.ModelsSpecificationDataRepository>();
            services.AddScoped<Repository.ICallSetupRequestDataRepository, Repository.CallSetupRequestDataRepository>();
            services.AddScoped<Repository.ISalesRepresentativeDataRepository, Repository.SalesRepresentativeDataRepository>();
            services.AddScoped<Utilities.IAlerter, Utilities.AlertByEmail>();
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
