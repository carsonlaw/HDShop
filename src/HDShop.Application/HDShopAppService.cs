using System;
using System.Collections.Generic;
using System.Text;
using HDShop.Localization;
using Volo.Abp.Application.Services;

namespace HDShop
{
    /* Inherit your application services from this class.
     */
    public abstract class HDShopAppService : ApplicationService
    {
        protected HDShopAppService()
        {
            LocalizationResource = typeof(HDShopResource);
        }
    }
}
