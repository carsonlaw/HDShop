using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using HDShop.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace HDShop.Web.Pages
{
    /* Inherit your UI Pages from this class. To do that, add this line to your Pages (.cshtml files under the Page folder):
     * @inherits HDShop.Web.Pages.HDShopPage
     */
    public abstract class HDShopPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<HDShopResource> L { get; set; }
    }
}
