using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.Hosting;

public static class BuilderPulseProHostBuilderExtensions
{
    public const string AppSettingsSecretJsonPath = "appsettings.keys.json";

    public static IHostBuilder AddAppSettingsKeysJson(
        this IHostBuilder hostBuilder,
        bool optional = true,
        bool reloadOnChange = true,
        string path = AppSettingsSecretJsonPath)
    {
        return hostBuilder.ConfigureAppConfiguration((_, builder) =>
        {
            builder.AddJsonFile(
                path: path,
                optional: optional,
                reloadOnChange: reloadOnChange
            );
        });
    }
}