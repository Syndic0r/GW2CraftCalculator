using GW2CraftCalculator;
using GW2CraftCalculator.Data.DependencyInjection;
using GW2CraftCalculator.DependencyInjection;
using GW2CraftCalculator.Interfaces;
using GW2CraftCalculator.Logic.DependencyInjection;
using GW2CraftCalculator.Translation.DependencyInjection;
using GW2CraftCalculator.Utils.DependencyInjection;
using GW2CraftCalculator.Utils.Factories;
using Microsoft.Extensions.Hosting;
using Serilog;

Console.InputEncoding = System.Text.Encoding.Unicode;
Console.OutputEncoding = System.Text.Encoding.Unicode;

try
{
    HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
    builder = ConfigureDependecyInjection(builder, args);
    using IHost host = builder.Build();
    await host.RunAsync();
}
catch (OperationCanceledException)
{
    WriteLog(log => log.Information("Application run was canceled."));
}
catch (HostAbortedException)
{
    WriteLog(log => log.Information("Host was aborted. This can happen when running EF Migration."));
}
catch (Exception ex)
{
    WriteLog(log => log.Fatal(ex, "General unexpected app exception encountered."),
        (gui) => ExceptionHandler.WriteErrorMessagesToConsole(ex, LogHookFactory.GetLogHook(), gui));
}
finally
{
    Log.CloseAndFlush();
}

static HostApplicationBuilder ConfigureDependecyInjection(HostApplicationBuilder builder, string[] args)
{
    builder.AddDataServices();
    builder.AddLogicServices();
    builder.AddAppServices();
    builder.AddUtilsServices();
    builder.AddTranslationServices();

    builder.ConfigureLogging();
    builder.ConfigureAppStart(args);

    return builder;
}

static void WriteLog(Action<ILogger> loggerAction, Action<IConsoleProcessor>? exceptionAction = null)
{
    Log.Logger = LoggerFactory.ConfigureLogger(LogHookFactory.GetLogHook);

    loggerAction(Log.Logger);

    if (exceptionAction != null)
    {
        IConsoleProcessor consoleProcessor = new ConsoleProcessor();
        exceptionAction?.Invoke(consoleProcessor);
    }

}
