﻿using HDShop.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace HDShop.Permissions
{
    public class HDShopPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(HDShopPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(HDShopPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HDShopResource>(name);
        }
    }
}
