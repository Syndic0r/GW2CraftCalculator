using GW2CraftCalculator.Interfaces.Utils;
using GW2CraftCalculator.Factories;
using GW2CraftCalculator.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console.Cli;

namespace GW2CraftCalculator.DependencyInjection;

internal static class ConfigureServices
{
    public static HostApplicationBuilder AddAppServices(this HostApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IConsoleProcessor, ConsoleProcessor>();
        builder.Services.AddSingleton<IExceptionHandler, ExceptionHandler>();
        builder.Services.AddSingleton<IMysticForgeUiFilterHandler, MysticForgeUiFilterHandler>();

        return builder;
    }

    public static HostApplicationBuilder ConfigureAppStart(this HostApplicationBuilder builder, string[] args)
    {
        builder.Services.AddHostedService<Startup>();
        builder.Services.AddSingleton(_ => new CommandLineArgs(args));
        builder.Services.AddSingleton<ITypeRegistrar, TypeRegistrar>(_ => new TypeRegistrar(builder.Services));
        builder.Services.AddSingleton<ICommandAppFactory, CommandAppFactory>();

        return builder;
    }
}
