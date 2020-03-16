using Volo.Abp.Modularity;

namespace HDShop
{
    [DependsOn(
        typeof(HDShopApplicationModule),
        typeof(HDShopDomainTestModule)
        )]
    public class HDShopApplicationTestModule : AbpModule
    {

    }
}