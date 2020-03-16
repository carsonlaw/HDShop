using HDShop.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace HDShop.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(HDShopEntityFrameworkCoreDbMigrationsModule),
        typeof(HDShopApplicationContractsModule)
        )]
    public class HDShopDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
