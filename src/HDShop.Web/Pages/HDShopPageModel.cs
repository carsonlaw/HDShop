using HDShop.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace HDShop.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class HDShopPageModel : AbpPageModel
    {
        protected HDShopPageModel()
        {
            LocalizationResourceType = typeof(HDShopResource);
        }
    }
}