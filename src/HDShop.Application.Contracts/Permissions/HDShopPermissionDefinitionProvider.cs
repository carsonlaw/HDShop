using HDShop.Localization;
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
            var good = myGroup.AddPermission(HDShopPermissions.GroupName + HDShopPermissions.GoodManager, L("Permission:GoodManager"));
            good.AddChild(HDShopPermissions.GoodManager + HDShopPermissions.AddName, L("Permission:Add"));
            good.AddChild(HDShopPermissions.GoodManager + HDShopPermissions.EditName, L("Permission:Edit"));
            good.AddChild(HDShopPermissions.GoodManager + HDShopPermissions.DeleteName, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<HDShopResource>(name);
        }
    }
}
