using HDShop.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HDShop.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class HDShopController : AbpController
    {
        protected HDShopController()
        {
            LocalizationResource = typeof(HDShopResource);
        }
    }
}