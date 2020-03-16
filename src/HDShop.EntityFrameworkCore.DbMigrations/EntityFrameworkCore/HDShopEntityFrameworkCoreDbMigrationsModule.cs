using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace HDShop.EntityFrameworkCore
{
    [DependsOn(
        typeof(HDShopEntityFrameworkCoreModule)
        )]
    public class HDShopEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<HDShopMigrationsDbContext>();
        }
    }
}
