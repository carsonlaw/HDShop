using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace HDShop.Web
{
    [Dependency(ReplaceServices = true)]
    public class HDShopBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "HDShop";
    }
}
