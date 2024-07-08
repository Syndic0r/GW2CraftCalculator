using Serilog.Sinks.File.Header;
using System.Text;

namespace GW2CraftCalculator.Utils.Logging;

public class LogHook : HeaderWriter
{
    private string? _filePath;

    public string FilePath => _filePath ?? string.Empty;

    public string FolderPath
    {
        get
        {
            if (string.IsNullOrEmpty(_filePath)) return string.Empty;
            string? folderPath = Path.GetDirectoryName(_filePath);
            return folderPath ?? _filePath;
        }
    }

    public LogHook(string header, bool alwaysWriteHeader = false) : base(header, alwaysWriteHeader) { }

    public LogHook(Func<string> headerFactory, bool alwaysWriteHeader = false) : base(headerFactory, alwaysWriteHeader) { }

    public override Stream OnFileOpened(string path, Stream underlyingStream, Encoding encoding)
    {
        _filePath = path;
        return base.OnFileOpened(path, underlyingStream, encoding);
    }
}
