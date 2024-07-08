using GW2CraftCalculator.Utils.Logging;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace GW2CraftCalculator.Utils.Factories;

public class LoggerFactory
{
    private static Logger? _defaultLogger;
    private static Logger? _extendedLogger;
    private static string? _logFilePath;

    public static Logger ConfigureLogger(Func<LogHook> logHook, LoggerConfiguration? loggerConfiguration = null)
    {
        return _defaultLogger ??= ConfigureLogger(logHook.Invoke(), loggerConfiguration);
    }

    public static Logger ConfigureLogger(LogHook logHook, LoggerConfiguration? loggerConfiguration = null)
    {
        loggerConfiguration ??= new LoggerConfiguration();
        _defaultLogger ??= ConfigureDefaultLoggerConfiguration(logHook, loggerConfiguration)
                        .CreateLogger();
        return _defaultLogger;
    }

    public static Logger ConfigureLogger(LoggingConfig config, Func<LogHook> logHook, LoggerConfiguration? loggerConfiguration = null)
    {
        return _extendedLogger ??= ConfigureLogger(config, logHook.Invoke(), loggerConfiguration);
    }

    public static Logger ConfigureLogger(LoggingConfig config, LogHook logHook, LoggerConfiguration? loggerConfiguration = null)
    {
        if (_extendedLogger != null)
        {
            return _extendedLogger;
        }

        if (_logFilePath == null)
        {
            SetLogFilePath(config.LogPath);
        }

        loggerConfiguration = ConfigureDefaultLoggerConfiguration(logHook, loggerConfiguration)
                                .MinimumLevel.Is(config.MinLogLevel);

        foreach (KeyValuePair<string, LogEventLevel> @override in config.Overrides)
        {
            loggerConfiguration.MinimumLevel.Override(@override.Key, @override.Value);
        }

        _extendedLogger = loggerConfiguration.CreateLogger();
        return _extendedLogger;
    }

    private static LoggerConfiguration ConfigureDefaultLoggerConfiguration(LogHook logHook, LoggerConfiguration? loggerConfiguration = null)
    {
        loggerConfiguration ??= new LoggerConfiguration();

        if (string.IsNullOrWhiteSpace(_logFilePath))
        {
            SetDefaultLogFilePath();
        }

        return loggerConfiguration
                .WriteTo.File(_logFilePath!,
                            rollingInterval: RollingInterval.Day,
                            retainedFileCountLimit: 7,
                            encoding: System.Text.Encoding.Unicode,
                            hooks: logHook)
                .Enrich.FromLogContext();
    }

    private static void SetDefaultLogFilePath()
    {
        string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        string logPath = Path.Combine(localAppData, AppDomain.CurrentDomain.FriendlyName);
        SetLogFilePath(logPath);
    }

    private static void SetLogFilePath(string? path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            SetDefaultLogFilePath();
            return;
        }

        string logFileScheme = "log-.txt";
        string logFilePath = Path.Combine(path!, logFileScheme);
        _logFilePath = logFilePath;
    }
}
