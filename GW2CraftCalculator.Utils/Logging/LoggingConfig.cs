using Serilog.Events;

namespace GW2CraftCalculator.Utils.Logging;

public class LoggingConfig
{
    public LogEventLevel MinLogLevel { get; set; }

    public Dictionary<string, LogEventLevel> Overrides { get; set; }

    public string? LogPath { get; set; }
}
