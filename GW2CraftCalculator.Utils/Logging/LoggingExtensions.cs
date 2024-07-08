using Newtonsoft.Json;

namespace GW2CraftCalculator.Utils.Logging;
public static class LoggingExtensions
{
    public static string ConvertReadable(this object? obj)
    {
        return JsonConvert.SerializeObject(obj);
    }
}
