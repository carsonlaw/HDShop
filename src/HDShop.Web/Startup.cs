using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HDShop.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<HDShopWebModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
