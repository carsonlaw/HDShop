using HDShop.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace HDShop
{
    [DependsOn(
        typeof(HDShopEntityFrameworkCoreTestModule)
        )]
    public class HDShopDomainTestModule : AbpModule
    {

    }
}