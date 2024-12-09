using BuilderPulsePro.Localization;
using Localization.Resources.AbpUi;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Gdpr;
using Volo.Abp.Identity;
using Volo.Abp.LanguageManagement;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.CmsKit;

namespace BuilderPulsePro;

[DependsOn(
    typeof(BuilderPulseProApplicationContractsModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpAccountAdminHttpApiModule),
    typeof(AbpAccountPublicHttpApiModule),
    typeof(TextTemplateManagementHttpApiModule),
    typeof(LanguageManagementHttpApiModule),
    typeof(AbpGdprHttpApiModule),
    typeof(CmsKitProHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule)
    )]
public class BuilderPulseProHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureLocalization();
    }

    private void ConfigureLocalization()
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<BuilderPulseProResource>()
                .AddBaseTypes(
                    typeof(AbpUiResource)
                );
        });
    }
}
