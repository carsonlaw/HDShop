using Volo.Abp.Settings;

namespace HDShop.Settings
{
    public class HDShopSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(HDShopSettings.MySetting1));
        }
    }
}
