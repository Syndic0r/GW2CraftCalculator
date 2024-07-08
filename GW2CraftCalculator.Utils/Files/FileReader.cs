using GW2CraftCalculator.Interfaces.Utils;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace GW2CraftCalculator.Utils.Files;
public class FileReader : IFileReader
{
    private readonly IHostEnvironment _hostEnvironment;
    private readonly ILogger<FileReader> _logger;

    public FileReader(IHostEnvironment hostEnvironment, ILogger<FileReader> logger)
    {
        _hostEnvironment = hostEnvironment;
        _logger = logger;
    }

    public async Task<TReturn> ReadFile<TReturn>(string fileName, CancellationToken cancellationToken) where TReturn : class
    {
        _logger.LogDebug("Start file reading process for file '{fileName}' in folder '{folderName}'", fileName, _hostEnvironment.ContentRootPath);
        IFileInfo fileInfo = _hostEnvironment.ContentRootFileProvider.GetFileInfo(fileName);
        TReturn? returnObj = null;
        if (fileInfo.Exists)
        {
            using Stream reader = fileInfo.CreateReadStream();
            using StreamReader fileReader = new(reader);
            _logger.LogDebug("Start reading file '{fileName}'...", fileName);
            if (cancellationToken.IsCancellationRequested)
            {
                fileReader.Dispose();
                reader.Dispose();
                cancellationToken.ThrowIfCancellationRequested();
            }
            string fileContent = await fileReader.ReadToEndAsync(cancellationToken);
            _logger.LogDebug("File reading finished. Starting to deserialize file to object of '{objectName}'", typeof(TReturn).Name);
            returnObj = JsonConvert.DeserializeObject<TReturn>(fileContent);
            _logger.LogDebug("File deserializing finished.");
        }
        else
        {
            const string format = "File '{0}' could not be found in app folder '{1}'.";
            string message = string.Format(format, fileName, _hostEnvironment.ContentRootPath);
            throw new FileNotFoundException(message, fileName);
        }

        if (returnObj == null)
        {
            const string format = "File '{0}' could not be deserialized to an object of '{1}'.";
            string message = string.Format(format, fileName, typeof(TReturn).Name);
            throw new NullReferenceException(message);
        }

        return returnObj;
    }
}
