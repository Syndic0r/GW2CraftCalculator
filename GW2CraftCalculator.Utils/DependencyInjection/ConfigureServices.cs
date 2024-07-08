using GW2CraftCalculator.Interfaces.Utils;
using GW2CraftCalculator.Utils.Converters;
using GW2CraftCalculator.Utils.Factories;
using GW2CraftCalculator.Utils.Files;
using GW2CraftCalculator.Utils.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace GW2CraftCalculator.Utils.DependencyInjection;

public static class ConfigureServices
{
    public static HostApplicationBuilder ConfigureLogging(this HostApplicationBuilder builder)
    {
        builder.Services.AddSingleton(_ => LogHookFactory.GetLogHook());

        LoggingConfig loggingConfig = builder.Configuration.GetRequiredSection("LoggingConfig").Get<LoggingConfig>()!;
        builder.Logging.Services.AddLogging(configure =>
        {
            configure.AddSerilog(LoggerFactory.ConfigureLogger(loggingConfig, LogHookFactory.GetLogHook));
        });

        return builder;
    }

    public static HostApplicationBuilder AddUtilsServices(this HostApplicationBuilder builder) 
    {
        builder.Services.AddSingleton<ILanguageConverter, LanguageConverter>();
        builder.Services.AddSingleton<ILocaleConverter, LocaleConverter>();
        builder.Services.AddSingleton<IFileReader, FileReader>();
        return builder;
    }
}
