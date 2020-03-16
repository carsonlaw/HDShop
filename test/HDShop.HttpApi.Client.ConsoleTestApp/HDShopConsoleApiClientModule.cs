using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace HDShop.HttpApi.Client.ConsoleTestApp
{
    [DependsOn(
        typeof(HDShopHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class HDShopConsoleApiClientModule : AbpModule
    {
        
    }
}
