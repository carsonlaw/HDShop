using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace HDShop
{
    public class HDShopWebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<HDShopWebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}