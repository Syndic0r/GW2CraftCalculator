using GW2CraftCalculator.Interfaces.Utils;
using GW2CraftCalculator.Interfaces;
using GW2CraftCalculator.Utils.Logging;
using Microsoft.Extensions.Logging;
using Spectre.Console;

namespace GW2CraftCalculator;

public class ExceptionHandler : IExceptionHandler
{
    private readonly ILogger<ExceptionHandler> _logger;
    private readonly LogHook _logHook;
    private readonly IConsoleProcessor _consoleProcessor;

    public ExceptionHandler(ILogger<ExceptionHandler> logger, LogHook logHook, IConsoleProcessor consoleProcessor)
    {
        _logger = logger;
        _logHook = logHook;
        _consoleProcessor = consoleProcessor;
    }

    public int HandleException(Exception exception)
    {
        _logger.LogError(exception, exception.Message);

        WriteErrorMessagesToConsole(exception, _logHook, _consoleProcessor);

        return -1;
    }

    public static void WriteErrorMessagesToConsole(Exception exception, LogHook logHook, IConsoleProcessor consoleProcessor)
    {
        string exMessage = consoleProcessor.CorrectMarkupText(exception.Message);
        consoleProcessor.WriteColoredText(exMessage, Color.Red3_1, Environment.NewLine + Environment.NewLine);

        const string errorMessage = "An Error occured. For more detailed Information open the logs:";
        consoleProcessor.WriteColoredText(errorMessage, Color.Red, Environment.NewLine);

        const string logFolderPath = "⮞ Log Folder ⮜";
        consoleProcessor.WriteColoredText(logFolderPath, Color.OrangeRed1, Environment.NewLine, logHook.FolderPath);

        const string logFilePath = "⮞ Log File ⮜";
        consoleProcessor.WriteColoredText(logFilePath, Color.OrangeRed1, Environment.NewLine, logHook.FilePath);
    }
}
