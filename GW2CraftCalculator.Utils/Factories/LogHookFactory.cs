using GW2CraftCalculator.Utils.Logging;

namespace GW2CraftCalculator.Utils.Factories;

public class LogHookFactory
{
    private static LogHook? _logHook;

    public static LogHook GetLogHook()
    {
        return _logHook ??= new("─────────────────────────────────────────────────────", true);
    }
}
