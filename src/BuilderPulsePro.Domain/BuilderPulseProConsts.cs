using Volo.Abp.Identity;

namespace BuilderPulsePro;

public static class BuilderPulseProConsts
{
    public const string DbTablePrefix = "Bpp";
    public const string? DbSchema = null;
    public const string AdminEmailDefaultValue = IdentityDataSeedContributor.AdminEmailDefaultValue;
    public const string AdminPasswordDefaultValue = IdentityDataSeedContributor.AdminPasswordDefaultValue;
}